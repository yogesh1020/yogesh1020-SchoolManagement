using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApi
{
    public partial class VStudentDetails
    {
        [Key]
        public int StudentId { get; set; }

        public string StudentName { get; set; }
        public DateTime StudentDob { get; set; }
        public string StudentGender { get; set; }
        public string Mobile { get; set; }
        public int Fee { get; set; }
    }
}
