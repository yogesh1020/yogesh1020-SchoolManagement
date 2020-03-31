using System;
using System.Collections.Generic;

namespace SchoolManagementApi
{
    public partial class Admissions
    {
        public int AdmissionId { get; set; }
        public int StudentId { get; set; }
        public int StandardId { get; set; }

        public virtual Standards Standard { get; set; }
        public virtual Students Student { get; set; }
    }
}
