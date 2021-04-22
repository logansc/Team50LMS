using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Professor
    {
        public Professor()
        {
            Class = new HashSet<Class>();
        }

        public string UId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime Dob { get; set; }
        public string Abrv { get; set; }

        public virtual Departments AbrvNavigation { get; set; }
        public virtual ICollection<Class> Class { get; set; }
    }
}
