using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Models.LMSModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
  [Authorize(Roles = "Administrator")]
  public class AdministratorController : CommonController
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Department(string subject)
    {
      ViewData["subject"] = subject;
      return View();
    }

    public IActionResult Course(string subject, string num)
    {
      ViewData["subject"] = subject;
      ViewData["num"] = num;
      return View();
    }

    /*******Begin code to modify********/

    /// <summary>
    /// Returns a JSON array of all the courses in the given department.
    /// Each object in the array should have the following fields:
    /// "number" - The course number (as in 5530)
    /// "name" - The course name (as in "Database Systems")
    /// </summary>
    /// <param name="subject">The department subject abbreviation (as in "CS")</param>
    /// <returns>The JSON result</returns>
    public IActionResult GetCourses(string subject)
    {
      var query =
        from c in db.Course
        where c.Abrv == subject
        select new
        {
          number = c.CNumber,
          name = c.CName
        };

      return Json(query.ToArray());
    }

   
    /// <summary>
    /// Returns a JSON array of all the professors working in a given department.
    /// Each object in the array should have the following fields:
    /// "lname" - The professor's last name
    /// "fname" - The professor's first name
    /// "uid" - The professor's uid
    /// </summary>
    /// <param name="subject">The department subject abbreviation</param>
    /// <returns>The JSON result</returns>
    public IActionResult GetProfessors(string subject)
    {
      var query =
        from p in db.Professor
        where p.Abrv == subject
        select new
        {
          lname = p.LName,
          fname = p.FName,
          uid = p.UId
        };
   
      return Json(query.ToArray());
    }



    /// <summary>
    /// Creates a course.
    /// A course is uniquely identified by its number + the subject to which it belongs
    /// </summary>
    /// <param name="subject">The subject abbreviation for the department in which the course will be added</param>
    /// <param name="number">The course number</param>
    /// <param name="name">The course name</param>
    /// <returns>A JSON object containing {success = true/false},
	/// false if the Course already exists.</returns>
    public IActionResult CreateCourse(string subject, int number, string name)
    {
      try
      {
        Course course = new Course() { Abrv = subject, CNumber = number, CName = name};
        db.Course.Add(course);
        db.SaveChanges();
        return Json(new { success = true });
      }
      catch
      {
        return Json(new { success = false });
      }

    }



    /// <summary>
    /// Creates a class offering of a given course.
    /// </summary>
    /// <param name="subject">The department subject abbreviation</param>
    /// <param name="number">The course number</param>
    /// <param name="season">The season part of the semester</param>
    /// <param name="year">The year part of the semester</param>
    /// <param name="start">The start time</param>
    /// <param name="end">The end time</param>
    /// <param name="location">The location</param>
    /// <param name="instructor">The uid of the professor</param>
    /// <returns>A JSON object containing {success = true/false}. 
    /// false if another class occupies the same location during any time 
    /// within the start-end range in the same semester, or if there is already
    /// a Class offering of the same Course in the same Semester.</returns>
    public IActionResult CreateClass(string subject, int number, string season, int year, DateTime start, DateTime end, string location, string instructor)
    {
      var query3 = (
        from cls in db.Class
        select new
        {
          classID = cls.ClassId
        }).Max(c => c.classID);

      int newClassId = query3 + 1;

      // Convert to values usable in our DB
      TimeSpan startTime = start.TimeOfDay;
      TimeSpan endTime = end.TimeOfDay;

      // Check for conflicting classes
      var query1 =
        from c in db.Class
        join r in db.Course
        on c.CourseId equals r.CourseId
        where (c.StartTime < endTime && c.EndTime > startTime) &&
        c.SemesterSeason == season &&
        c.SemesterYear == year &&
        c.Location == location ||
        r.Abrv == subject &&
        r.CNumber == number      
        select new
        {
          conflictingClass = c
        };

      // If the query found results, there is at least one conflicting class
      if (query1.Any())
      {
        return Json(new { success = false });
      }
      else
      {
        // Otherwise get the courseID so we can use it in creating the class
        var query2 =
          (from r in db.Course
          where r.Abrv == subject
          where r.CNumber == number
          select new
          {
            courseID = r.CourseId
          }).FirstOrDefault();

        // Create class
        Class lmsClass = new Class() 
        {
          ClassId = newClassId,
          SemesterYear = (uint)year,
          SemesterSeason = season,
          StartTime = start.TimeOfDay,
          EndTime = end.TimeOfDay,
          Location = location,
          UId = instructor,
          CourseId = query2.courseID
         };

        db.Class.Add(lmsClass);
        db.SaveChanges();

        return Json(new { success = true });
      }

    }


    /*******End code to modify********/

  }
}