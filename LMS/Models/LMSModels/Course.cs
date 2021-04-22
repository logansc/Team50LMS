using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Course
    {
        public Course()
        {
            Class = new HashSet<Class>();
        }

        public int CourseId { get; set; }
        public int CNumber { get; set; }
        public string CName { get; set; }
        public string Abrv { get; set; }

        public virtual Departments AbrvNavigation { get; set; }
        public virtual ICollection<Class> Class { get; set; }
    }
}
