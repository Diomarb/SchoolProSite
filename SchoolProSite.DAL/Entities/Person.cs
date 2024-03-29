﻿

using SchoolProSite.DAL.Core;

namespace SchoolProSite.DAL.Entities
{
    public partial class Person 
    {
        public Person()
        {
            StudentGrades = new HashSet<StudentGrade>();
            Course = new HashSet<Course>();
        }

        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
       
        public DateTime? HireDate { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string Discriminator { get; set; }

        public virtual OfficeAssigment OfficeAssignment { get; set; }
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
}