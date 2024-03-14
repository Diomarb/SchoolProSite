
using Microsoft.EntityFrameworkCore;
using SchoolProSite.DAL.Entities;

namespace SchoolProSite.DAL.Context
{
    public class SchoolContext : DbContext

    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }
        #region "Entities"
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<OnlineCourse> OnlineCourses { get; set; }
        public DbSet<OnsiteCourse> OnsiteCourses { get; set; }
        public DbSet<OfficeAssigment> OfficeAssignments { get; set; }
        public DbSet<StudentGrade> StudentGrades { get; set; }

        #endregion







    }
}
