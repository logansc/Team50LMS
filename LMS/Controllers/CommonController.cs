using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Models.LMSModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS.Controllers
{
  public class CommonController : Controller
  {

    /*******Begin code to modify********/

    // TODO: Uncomment and change 'X' after you have scaffoled


    protected Team50LMSContext db;

    public CommonController()
    {
      db = new Team50LMSContext();
    }


    /*
     * WARNING: This is the quick and easy way to make the controller
     *          use a different LibraryContext - good enough for our purposes.
     *          The "right" way is through Dependency Injection via the constructor 
     *          (look this up if interested).
    */

    // TODO: Uncomment and change 'X' after you have scaffoled

    public void UseLMSContext(Team50LMSContext ctx)
    {
      db = ctx;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }




    /// <summary>
    /// Retreive a JSON array of all departments from the database.
    /// Each object in the array should have a field called "name" and "subject",
    /// where "name" is the department name and "subject" is the subject abbreviation.
    /// </summary>
    /// <returns>The JSON array</returns>
    public IActionResult GetDepartments()
    {
      var query =
                from d in db.Departments
                select new
                {
                  name = d.DName,
                  subject = d.Abrv
                };

      return Json(query.ToArray());
    }



    /// <summary>
    /// Returns a JSON array representing the course catalog.
    /// Each object in the array should have the following fields:
    /// "subject": The subject abbreviation, (e.g. "CS")
    /// "dname": The department name, as in "Computer Science"
    /// "courses": An array of JSON objects representing the courses in the department.
    ///            Each field in this inner-array should have the following fields:
    ///            "number": The course number (e.g. 5530)
    ///            "cname": The course name (e.g. "Database Systems")
    /// </summary>
    /// <returns>The JSON array</returns>
    public IActionResult GetCatalog()
    {
      var query =
              from d in db.Departments
              select new
              {
                subject = d.Abrv,
                dname = d.DName,
                courses = d.Course.Select((key, index) => new { number = key.CNumber, cname = key.CName })
              };

      return Json(query.ToArray());
    }

    /// <summary>
    /// Returns a JSON array of all class offerings of a specific course.
    /// Each object in the array should have the following fields:
    /// "season": the season part of the semester, such as "Fall"
    /// "year": the year part of the semester
    /// "location": the location of the class
    /// "start": the start time in format "hh:mm:ss"
    /// "end": the end time in format "hh:mm:ss"
    /// "fname": the first name of the professor
    /// "lname": the last name of the professor
    /// </summary>
    /// <param name="subject">The subject abbreviation, as in "CS"</param>
    /// <param name="number">The course number, as in 5530</param>
    /// <returns>The JSON array</returns>
    public IActionResult GetClassOfferings(string subject, int number)
    {
      var query =
                  from c in db.Class
                  where c.Course.CNumber == number
                  where c.Course.Abrv == subject
                  select new
                  {
                    season = c.SemesterSeason,//.Substring(0, c.SemesterSeason.IndexOf(" ")),
                          year = c.SemesterYear,
                    location = c.Location,
                    start = c.StartTime,
                    end = c.EndTime,
                    fname = c.U.FName,
                    lname = c.U.LName
                  };

      return Json(query.ToArray());
    }

    /// <summary>
    /// This method does NOT return JSON. It returns plain text (containing html).
    /// Use "return Content(...)" to return plain text.
    /// Returns the contents of an assignment.
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The name of the assignment category in the class</param>
    /// <param name="asgname">The name of the assignment in the category</param>
    /// <returns>The assignment contents</returns>
    public IActionResult GetAssignmentContents(string subject, int num, string season, int year, string category, string asgname)
    {
      var query =
              from a in db.Assignments
              join cat in db.AssignmentCat
              on a.AcId equals cat.AcId
              join c in db.Class
              on cat.ClassId equals c.ClassId
              where c.Course.Abrv == subject
              where c.Course.CNumber == num
              where c.SemesterSeason == season
              where c.SemesterYear == year
              where cat.CatName == category
              where a.AName == asgname
              select new
              {
                contents = a.Instructions
              };


      return Content(query.ToString());
    }


    /// <summary>
    /// This method does NOT return JSON. It returns plain text (containing html).
    /// Use "return Content(...)" to return plain text.
    /// Returns the contents of an assignment submission.
    /// Returns the empty string ("") if there is no submission.
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The name of the assignment category in the class</param>
    /// <param name="asgname">The name of the assignment in the category</param>
    /// <param name="uid">The uid of the student who submitted it</param>
    /// <returns>The submission text</returns>
    public IActionResult GetSubmissionText(string subject, int num, string season, int year, string category, string asgname, string uid)
    {
      var query =
        from s in db.Submissions
        join a in db.Assignments
        on s.Assignment equals a.AsnId
        join t in db.AssignmentCat
        on a.AcId equals t.AcId
        join c in db.Class
        on t.ClassId equals c.ClassId
        join r in db.Course
        on c.CourseId equals r.CourseId
        where r.Abrv == subject
        where r.CNumber == num
        where c.SemesterSeason == season
        where c.SemesterYear == year
        where t.CatName == category
        where a.AName == asgname
        where s.Student == uid
        select new
        {
          contents = s.SubmissionContents
        };

         
      return Content(query.ToString());
    }


    /// <summary>
    /// Gets information about a user as a single JSON object.
    /// The object should have the following fields:
    /// "fname": the user's first name
    /// "lname": the user's last name
    /// "uid": the user's uid
    /// "department": (professors and students only) the name (such as "Computer Science") of the department for the user. 
    ///               If the user is a Professor, this is the department they work in.
    ///               If the user is a Student, this is the department they major in.    
    ///               If the user is an Administrator, this field is not present in the returned JSON
    /// </summary>
    /// <param name="uid">The ID of the user</param>
    /// <returns>
    /// The user JSON object 
    /// or an object containing {success: false} if the user doesn't exist
    /// </returns>
    public IActionResult GetUser(string uid)
    {

            var query1 = 
                     from s in db.Student
                     where s.UId == uid
                     select new {
                         fname = s.FName,
                         lname = s.LName,
                         uid = s.UId,
                         department = s.AbrvNavigation.DName
                         
                     };


            var query2 =
                     from p in db.Professor
                     where p.UId == uid
                     select new {
                         fname = p.FName,
                         lname = p.LName,
                         uid = p.UId,
                         department = p.AbrvNavigation.DName
                     };

            var query3 =
                     from a in db.Administrator
                     where a.UId == uid
                     select new {
                         fname = a.FName,
                         lname = a.LName,
                         uid = a.UId
                     };

            if (query1 != null) return Json(query1.FirstOrDefault());
            if (query2 != null) return Json(query2.FirstOrDefault());
            if (query3 != null) return Json(query3.FirstOrDefault());

            return Json(new { success = false });
    }


    /*******End code to modify********/

  }
}