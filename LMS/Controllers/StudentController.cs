using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Models.LMSModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
  [Authorize(Roles = "Student")]
  public class StudentController : CommonController
  {

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Catalog()
    {
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


    public IActionResult ClassListings(string subject, string num)
    {
      System.Diagnostics.Debug.WriteLine(subject + num);
      ViewData["subject"] = subject;
      ViewData["num"] = num;
      return View();
    }


    /*******Begin code to modify********/

    /// <summary>
    /// Returns a JSON array of the classes the given student is enrolled in.
    /// Each object in the array should have the following fields:
    /// "subject" - The subject abbreviation of the class (such as "CS")
    /// "number" - The course number (such as 5530)
    /// "name" - The course name
    /// "season" - The season part of the semester
    /// "year" - The year part of the semester
    /// "grade" - The grade earned in the class, or "--" if one hasn't been assigned
    /// </summary>
    /// <param name="uid">The uid of the student</param>
    /// <returns>The JSON array</returns>
    public IActionResult GetMyClasses(string uid)
    {
      var query =
        from e in db.Enroll
        join c in db.Class
        on e.ClassId equals c.ClassId
        join r in db.Course
        on c.CourseId equals r.CourseId
        where e.UId == uid
        select new
        {
          subject = r.Abrv,
          number = r.CNumber,
          name = r.CName,
          season = c.SemesterSeason,
          year = c.SemesterYear,
          grade = e.Grade
        };         
   
      return Json(query.ToArray());
    }

    /// <summary>
    /// Returns a JSON array of all the assignments in the given class that the given student is enrolled in.
    /// Each object in the array should have the following fields:
    /// "aname" - The assignment name
    /// "cname" - The category name that the assignment belongs to
    /// "due" - The due Date/Time
    /// "score" - The score earned by the student, or null if the student has not submitted to this assignment.
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="uid"></param>
    /// <returns>The JSON array</returns>
    public IActionResult GetAssignmentsInClass(string subject, int num, string season, int year, string uid)
    {       
      var query1 =
        from e in db.Enroll
        where e.UId == uid &&
        e.Class.SemesterSeason == season &&
        e.Class.SemesterYear == year &&
        e.Class.Course.Abrv == subject &&
        e.Class.Course.CNumber == num
        from a in db.Assignments
        where a.Ac.ClassId == e.Class.ClassId
        select a;

        var query2 =
        from q in query1
        join s in db.Submissions
        on new { A = q.AsnId, B = uid } equals new { A = s.Assignment, B = s.Student }
        into joined
        from j in joined.DefaultIfEmpty()
        select new
        {
          aname = q.AName,
          cname = q.Ac.CatName,
          due = q.DueDate,
          score = j == null ? null : (uint?)j.Score
        };

        return Json(query2.ToArray());
   
    }



    /// <summary>
    /// Adds a submission to the given assignment for the given student
    /// The submission should use the current time as its DateTime
    /// You can get the current time with DateTime.Now
    /// The score of the submission should start as 0 until a Professor grades it
    /// If a Student submits to an assignment again, it should replace the submission contents
    /// and the submission time (the score should remain the same).
	/// Does *not* automatically reject late submissions.
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name=" season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The name of the assignment category in the class</param>
    /// <param name="asgname">The new assignment name</param>
    /// <param name="uid">The student submitting the assignment</param>
    /// <param name="contents">The text contents of the student's submission</param>
    /// <returns>A JSON object containing {success = true/false}.</returns>
    public IActionResult SubmitAssignmentText(string subject, int num, string season, int year, 
      string category, string asgname, string uid, string contents)
    {
      try
      {
        var query = (
          from asg in db.Assignments
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
            assignmentId = asg.AsnId
          }).FirstOrDefault();

        // Check if there's already a submission
        var query2 = (
          from sub in db.Submissions
          where sub.Student == uid
          where sub.Assignment == query.assignmentId
          select sub).FirstOrDefault();

        // If there's already a submission, just change the contents
        if (query2 != null)
        {
          query2.SubmissionContents = contents;
          db.SaveChanges();
          return Json(new { success = true });
        }

        // If there's no submission, create a new one
        Submissions submission = new Submissions()
        {
          Assignment = query.assignmentId,
          Student = uid,
          Score = 0,
          SubmissionContents = contents,
          Time = DateTime.Now
        };

        db.Submissions.Add(submission);
        db.SaveChanges();
        return Json(new { success = true });

      }
      catch
      {
        return Json(new { success = false });
      }

    }

    
    /// <summary>
    /// Enrolls a student in a class.
    /// </summary>
    /// <param name="subject">The department subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester</param>
    /// <param name="year">The year part of the semester</param>
    /// <param name="uid">The uid of the student</param>
    /// <returns>A JSON object containing {success = {true/false},
	/// false if the student is already enrolled in the Class.</returns>
    public IActionResult Enroll(string subject, int num, string season, int year, string uid)
    {

      try
      {
        var query = (
          from cls in db.Class
          join crs in db.Course
          on cls.CourseId equals crs.CourseId
          where crs.Abrv == subject
          where crs.CNumber == num
          where cls.SemesterSeason == season
          where cls.SemesterYear == year
          select new
          {
            classId = cls.ClassId
          }).FirstOrDefault();

        Enroll enrollment = new Enroll()
        {
          Grade = "--",
          UId = uid,
          ClassId = query.classId
        };

        db.Add(enrollment);
        db.SaveChanges();
        return Json(new { success = true });

      }
      catch
      {
        return Json(new { success = false });
      }
    }



    /// <summary>
    /// Calculates a student's GPA
    /// A student's GPA is determined by the grade-point representation of the average grade in all their classes.
    /// Assume all classes are 4 credit hours.
    /// If a student does not have a grade in a class ("--"), that class is not counted in the average.
    /// If a student does not have any grades, they have a GPA of 0.0.
    /// Otherwise, the point-value of a letter grade is determined by the table on this page:
    /// https://advising.utah.edu/academic-standards/gpa-calculator-new.php
    /// </summary>
    /// <param name="uid">The uid of the student</param>
    /// <returns>A JSON object containing a single field called "gpa" with the number value</returns>
    public IActionResult GetGPA(string uid)
    {
      var query =
        from e in db.Enroll
        where e.UId == uid
        select new
        {
          grade = e.Grade
        };

      double gradeSum = 0;
      int gradeCount = 0;
      foreach (var row in query)
      {
        double? numberGrade = ControllerHelpers.letterToNumberGrade(row.grade);

        if (!(numberGrade is null))
        {
          gradeCount++;
          gradeSum += (double)numberGrade;
        }
      }

      if (gradeCount == 0)
        return Json(new { gpa = 0 });

      double GPA = gradeSum / gradeCount;
      return Json(new { gpa = GPA });
    }

    /*******End code to modify********/

  }
}