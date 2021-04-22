using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Student
    {
        public Student()
        {
            Enroll = new HashSet<Enroll>();
            Submissions = new HashSet<Submissions>();
        }

        public string UId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime Dob { get; set; }
        public string Abrv { get; set; }

        public virtual Departments AbrvNavigation { get; set; }
        public virtual ICollection<Enroll> Enroll { get; set; }
        public virtual ICollection<Submissions> Submissions { get; set; }
    }
}
