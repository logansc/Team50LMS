using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class AssignmentCat
    {
        public AssignmentCat()
        {
            Assignments = new HashSet<Assignments>();
        }

        public int ClassId { get; set; }
        public string CatName { get; set; }
        public uint GradeWeight { get; set; }
        public uint AcId { get; set; }

        public virtual Class Class { get; set; }
        public virtual ICollection<Assignments> Assignments { get; set; }
    }
}
