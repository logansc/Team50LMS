using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Class
    {
        public Class()
        {
            AssignmentCat = new HashSet<AssignmentCat>();
            Enroll = new HashSet<Enroll>();
        }

        public int ClassId { get; set; }
        public uint? SemesterYear { get; set; }
        public string SemesterSeason { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Location { get; set; }
        public string UId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Professor U { get; set; }
        public virtual ICollection<AssignmentCat> AssignmentCat { get; set; }
        public virtual ICollection<Enroll> Enroll { get; set; }
    }
}
