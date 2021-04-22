using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Enroll
    {
        public string Grade { get; set; }
        public string UId { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; }
        public virtual Student U { get; set; }
    }
}
