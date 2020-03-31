using System;
using System.Collections.Generic;

namespace SchoolManagementApi
{
    public partial class Students
    {
        public Students()
        {
            Admissions = new HashSet<Admissions>();
            Installments = new HashSet<Installments>();
            Standards = new HashSet<Standards>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime StudentDob { get; set; }
        public string StudentGender { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Admissions> Admissions { get; set; }
        public virtual ICollection<Installments> Installments { get; set; }
        public virtual ICollection<Standards> Standards { get; set; }
    }
}
