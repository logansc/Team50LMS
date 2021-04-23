using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers
{
  public static class ControllerHelpers
  {

    public static string numberToLetterGrade(double numberGrade)
    {
      switch (numberGrade)
      {
        case double n when(n >= 93):
          return "A";
        case double n when (n >= 90):
          return "A-";
        case double n when (n >= 87):
          return "B+";
        case double n when (n >= 83):
          return "B";
        case double n when (n >= 80):
          return "B-";
        case double n when (n >= 77):
          return "C+";
        case double n when (n >= 73):
          return "C";
        case double n when (n >= 70):
          return "C-";
        case double n when (n >= 67):
          return "D+";
        case double n when (n >= 63):
          return "D";
        case double n when (n >= 60):
          return "D-";
        case double n when (n >= 0):
          return "E";
        default:
          return "--";
      }
    }

    public static double? letterToNumberGrade(string letterGrade)
    {
      switch (letterGrade)
      {
        case "A":
          return 4.0;
        case "A-":
          return 3.7;
        case "B+":
          return 3.3;
        case "B":
          return 3.0;
        case "B-":
          return 2.7;
        case "C+":
          return 2.3;
        case "C":
          return 2.0;
        case "C-":
          return 1.7;
        case "D+":
          return 1.3;
        case "D":
          return 1.0;
        case "D-":
          return 0.7;
        case "E":
          return 0.0;
        default:
          return null;
      }
    }

  }
}
