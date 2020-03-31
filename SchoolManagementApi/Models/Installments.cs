using System;
using System.Collections.Generic;

namespace SchoolManagementApi
{
    public partial class Installments
    {
        public int InstallmentId { get; set; }
        public int StudentId { get; set; }
        public int StandardId { get; set; }
        public string StudentName { get; set; }
        public int Amount { get; set; }

        public virtual Standards Standard { get; set; }
        public virtual Students Student { get; set; }
    }
}
