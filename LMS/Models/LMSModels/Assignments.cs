using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Assignments
    {
        public Assignments()
        {
            Submissions = new HashSet<Submissions>();
        }

        public string AName { get; set; }
        public uint PointValue { get; set; }
        public DateTime DueDate { get; set; }
        public string Instructions { get; set; }
        public uint AcId { get; set; }
        public uint AsnId { get; set; }

        public virtual AssignmentCat Ac { get; set; }
        public virtual ICollection<Submissions> Submissions { get; set; }
    }
}
