using System;
using System.Collections.Generic;

namespace SchoolManagementApi
{
    public partial class Standards
    {
        public Standards()
        {
            Admissions = new HashSet<Admissions>();
            Installments = new HashSet<Installments>();
        }

        public int StandardId { get; set; }
        public int StudentId { get; set; }
        public string StandardName { get; set; }
        public int Fee { get; set; }

        public virtual Students Student { get; set; }
        public virtual ICollection<Admissions> Admissions { get; set; }
        public virtual ICollection<Installments> Installments { get; set; }
    }
}
