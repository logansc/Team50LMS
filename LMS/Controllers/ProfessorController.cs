using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Models.LMSModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
  [Authorize(Roles = "Professor")]
  public class ProfessorController : CommonController
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Students(string subject, string num, string season, string year)
    {
      ViewData["subject"] = subject;
      ViewData["num"] = num;
      ViewData["season"] = season;
      ViewData["year"] = year;
      return View();
    }

    public IActionResult Class(string subject, string num, string season, string year)
    {
      ViewData["subject"] = subject;
      ViewData["num"] = num;
      ViewData["season"] = season;
      ViewData["year"] = year;
      return View();
    }

    public IActionResult Categories(string subject, string num, string season, string year)
    {
      ViewData["subject"] = subject;
      ViewData["num"] = num;
      ViewData["season"] = season;
      ViewData["year"] = year;
      return View();
    }

    public IActionResult CatAssignments(string subject, string num, string season, string year, string cat)
    {
      ViewData["subject"] = subject;
      ViewData["num"] = num;
      ViewData["season"] = season;
      ViewData["year"] = year;
      ViewData["cat"] = cat;
      return View();
    }

    public IActionResult Assignment(string subject, string num, string season, string year, string cat, string aname)
    {
      ViewData["subject"] = subject;
      ViewData["num"] = num;
      ViewData["season"] = season;
      ViewData["year"] = year;
      ViewData["cat"] = cat;
      ViewData["aname"] = aname;
      return View();
    }

    public IActionResult Submissions(string subject, string num, string season, string year, string cat, string aname)
    {
      ViewData["subject"] = subject;
      ViewData["num"] = num;
      ViewData["season"] = season;
      ViewData["year"] = year;
      ViewData["cat"] = cat;
      ViewData["aname"] = aname;
      return View();
    }

    public IActionResult Grade(string subject, string num, string season, string year, string cat, string aname, string uid)
    {
      ViewData["subject"] = subject;
      ViewData["num"] = num;
      ViewData["season"] = season;
      ViewData["year"] = year;
      ViewData["cat"] = cat;
      ViewData["aname"] = aname;
      ViewData["uid"] = uid;
      return View();
    }

    /*******Begin code to modify********/


    /// <summary>
    /// Returns a JSON array of all the students in a class.
    /// Each object in the array should have the following fields:
    /// "fname" - first name
    /// "lname" - last name
    /// "uid" - user ID
    /// "dob" - date of birth
    /// "grade" - the student's grade in this class
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <returns>The JSON array</returns>
    public IActionResult GetStudentsInClass(string subject, int num, string season, int year)
    {
      var query =
          from course in db.Course
          join clas in db.Class
          on course.CourseId equals clas.CourseId
          join enroll in db.Enroll
          on clas.ClassId equals enroll.ClassId
          join student in db.Student
          on enroll.UId equals student.UId
          where subject == course.AbrvNavigation.Abrv
          where num == course.CNumber
          where season == clas.SemesterSeason
          where year == clas.SemesterYear
          select new
          {
            fname = student.FName,
            lname = student.LName,
            uid = student.UId,
            dob = student.Dob,
            grade = enroll.Grade

          };

      return Json(query.ToArray());
    }



    /// <summary>
    /// Returns a JSON array with all the assignments in an assignment category for a class.
    /// If the "category" parameter is null, return all assignments in the class.
    /// Each object in the array should have the following fields:
    /// "aname" - The assignment name
    /// "cname" - The assignment category name.
    /// "due" - The due DateTime
    /// "submissions" - The number of submissions to the assignment
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The name of the assignment category in the class, 
    /// or null to return assignments from all categories</param>
    /// <returns>The JSON array</returns>
    public IActionResult GetAssignmentsInCategory(string subject, int num, string season, int year, string category)
    {
      if (category == null)
      {
        var query =
          from course in db.Course
          join clas in db.Class
          on course.CourseId equals clas.CourseId
          join ac in db.AssignmentCat
          on clas.ClassId equals ac.ClassId
          join a in db.Assignments
          on ac.AcId equals a.AcId
          where subject == course.AbrvNavigation.Abrv
          where num == course.CNumber
          where season == clas.SemesterSeason
          where year == clas.SemesterYear
          select new
          {
            aname = a.AName,
            cname = ac.CatName,
            due = a.DueDate,
            submissions = a.Submissions.Count
          };

        return Json(query.ToArray());
      }
      else
      {

        var query =
          from course in db.Course
          join clas in db.Class
          on course.CourseId equals clas.CourseId
          join ac in db.AssignmentCat
          on clas.ClassId equals ac.ClassId
          join a in db.Assignments
          on ac.AcId equals a.AcId
          where subject == course.AbrvNavigation.Abrv
          where num == course.CNumber
          where season == clas.SemesterSeason
          where year == (uint)clas.SemesterYear
          where category == ac.CatName
          select new
          {
            aname = a.AName,
            cname = ac.CatName,
            due = a.DueDate,
            submissions = a.Submissions.Count
          };

        return Json(query.ToArray());


      }
    }


    /// <summary>
    /// Returns a JSON array of the assignment categories for a certain class.
    /// Each object in the array should have the folling fields:
    /// "name" - The category name
    /// "weight" - The category weight
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The name of the assignment category in the class</param>
    /// <returns>The JSON array</returns>
    public IActionResult GetAssignmentCategories(string subject, int num, string season, int year)
    {

      var query =
          from course in db.Course
          join clas in db.Class
          on course.CourseId equals clas.CourseId
          join categories in db.AssignmentCat
          on clas.ClassId equals categories.ClassId
          where subject == course.AbrvNavigation.Abrv
          where num == course.CNumber
          where season == clas.SemesterSeason
          where year == clas.SemesterYear
          select new
          {

            name = categories.CatName,
            weight = categories.GradeWeight
          };


      return Json(query.ToArray());
    }

    /// <summary>
    /// Creates a new assignment category for the specified class.
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The new category name</param>
    /// <param name="catweight">The new category weight</param>
    /// <returns>A JSON object containing {success = true/false},
    ///	false if an assignment category with the same name already exists in the same class.</returns>
    public IActionResult CreateAssignmentCategory(string subject, int num, string season, int year, string category, int catweight)
    {

      try
      {
        int classId = 0;

        var query =
            from clas in db.Class
            join course in db.Course
            on clas.CourseId equals course.CourseId
            where course.AbrvNavigation.Abrv == subject
            where clas.SemesterSeason == season
            where clas.SemesterYear == year
            select new
            {
              id = clas.ClassId
            };

        foreach (var q in query)
        {
          classId = (int)q.id;
        }


        AssignmentCat c = new AssignmentCat();
        c.CatName = category;
        c.GradeWeight = (uint)catweight;
        c.ClassId = classId;
        db.AssignmentCat.Add(c);
        db.SaveChanges();

        return Json(new { success = true });



      }
      catch (Exception)
      {

        return Json(new { success = false });

      }


    }

    /// <summary>
    /// Creates a new assignment for the given class and category.
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The name of the assignment category in the class</param>
    /// <param name="asgname">The new assignment name</param>
    /// <param name="asgpoints">The max point value for the new assignment</param>
    /// <param name="asgdue">The due DateTime for the new assignment</param>
    /// <param name="asgcontents">The contents of the new assignment</param>
    /// <returns>A JSON object containing success = true/false,
    /// false if an assignment with the same name already exists in the same assignment category.</returns>
    public IActionResult CreateAssignment(string subject, int num, string season, int year, string category, string asgname, int asgpoints, DateTime asgdue, string asgcontents)
    {
      try
      {

        int catId = 0;
        int classId = 0;

        var query1 =
            from clas in db.Class
            join course in db.Course
            on clas.CourseId equals course.CourseId
            where course.CNumber == num
            where clas.SemesterSeason == season
            where clas.SemesterYear == year
            select new
            {
              clID = clas.ClassId
            };


        foreach (var q in query1)
        {
          classId = (int)q.clID;
        }


        var query2 =
            from cat in db.AssignmentCat
            where cat.CatName == category
            where cat.ClassId == classId
            select new
            {

              c = cat.AcId
            };

        foreach (var q in query2)
        {
          catId = (int)q.c;
        }


        Assignments a = new Assignments();
        a.AName = asgname;
        a.Instructions = asgcontents;
        a.DueDate = asgdue;
        a.PointValue = (uint)asgpoints;
        a.AcId = (uint)catId;
        db.Assignments.Add(a);
        db.SaveChanges();


        return Json(new { success = true });


      }
      catch (Exception e)
      {

        return Json(new { success = false });


      }

    }


    /// <summary>
    /// Gets a JSON array of all the submissions to a certain assignment.
    /// Each object in the array should have the following fields:
    /// "fname" - first name
    /// "lname" - last name
    /// "uid" - user ID
    /// "time" - DateTime of the submission
    /// "score" - The score given to the submission
    /// 
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The name of the assignment category in the class</param>
    /// <param name="asgname">The name of the assignment</param>
    /// <returns>The JSON array</returns>
    public IActionResult GetSubmissionsToAssignment(string subject, int num, string season, int year, string category, string asgname)
    {
      var query =
        from stu in db.Student
        join sub in db.Submissions
        on stu.UId equals sub.Student
        join asg in db.Assignments
        on sub.Assignment equals asg.AsnId
        join asc in db.AssignmentCat
        on asg.AcId equals asc.AcId
        join cls in db.Class
        on asc.ClassId equals cls.ClassId
        join crs in db.Course
        on cls.CourseId equals crs.CourseId
        where crs.Abrv == subject
        where crs.CNumber == num
        where cls.SemesterSeason == season
        where cls.SemesterYear == year
        where asc.CatName == category
        where asg.AName == asgname
        select new
        {
          fname = stu.FName,
          lname = stu.LName,
          uid = stu.UId,
          time = sub.Time,
          score = sub.Score
        };

      return Json(query.ToArray());
    }


    /// <summary>
    /// Set the score of an assignment submission
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The name of the assignment category in the class</param>
    /// <param name="asgname">The name of the assignment</param>
    /// <param name="uid">The uid of the student who's submission is being graded</param>
    /// <param name="score">The new score for the submission</param>
    /// <returns>A JSON object containing success = true/false</returns>
    public IActionResult GradeSubmission(string subject, int num, string season, int year, string category, string asgname, string uid, int score)
    {
      try
      {
        var query = (
          from sub in db.Submissions
          join asg in db.Assignments
          on sub.Assignment equals asg.AsnId
          join asc in db.AssignmentCat
          on asg.AcId equals asc.AcId
          join cls in db.Class
          on asc.ClassId equals cls.ClassId
          join crs in db.Course
          on cls.CourseId equals crs.CourseId
          where crs.Abrv == subject
          where crs.CNumber == num
          where cls.SemesterSeason == season
          where cls.SemesterYear == year
          where asc.CatName == category
          where asg.AName == asgname
          where sub.Student == uid
          select new
          {
            assignmentId = asg.AsnId,
            studentId = sub.Student,
            submissionContents = sub.SubmissionContents,
            time = sub.Time
          }).FirstOrDefault();

        Submissions gradedSubmission = new Submissions()
        {
          Assignment = query.assignmentId,
          Student = uid,
          Score = (uint)score,
          SubmissionContents = query.submissionContents,
          Time = query.time
        };


        db.Add(gradedSubmission);
        db.SaveChanges();
        return Json(new { success = true });
      }
      catch
      {
        return Json(new { success = false });
      }

    }


    /// <summary>
    /// Returns a JSON array of the classes taught by the specified professor
    /// Each object in the array should have the following fields:
    /// "subject" - The subject abbreviation of the class (such as "CS")
    /// "number" - The course number (such as 5530)
    /// "name" - The course name
    /// "season" - The season part of the semester in which the class is taught
    /// "year" - The year part of the semester in which the class is taught
    /// </summary>
    /// <param name="uid">The professor's uid</param>
    /// <returns>The JSON array</returns>
    public IActionResult GetMyClasses(string uid)
    {
      var query =
       from cls in db.Class
       join crs in db.Course
       on cls.UId equals uid
       select new
       {
        subject = crs.Abrv,
        number = crs.CNumber,
        name = crs.CName,
        season = cls.SemesterSeason,
        year = cls.SemesterYear
       };

      return Json(query.ToArray());
    }


    /*******End code to modify********/

  }
}