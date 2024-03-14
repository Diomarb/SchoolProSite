
using Microsoft.EntityFrameworkCore;
using SchoolProSite.DAL.Context;
using SchoolProSite.DAL.Entities;
using SchoolProSite.DAL.Exceptions;
using SchoolProSite.DAL.Interfaces;
using SchoolProSite.DAL.Models;


namespace SchoolProSite.DAL.Dao
{
    public class DaoCourse : IDaoCourse
    {
        private readonly SchoolContext context;

        public DaoCourse(SchoolContext context)
        {
            this.context = context;
        }
        public bool ExistsCourse(Func<Course, bool> filter)
        {
            return this.context.Course.Any(filter);
        }

        public CourseDaoModel GetCourse(int Id)
        {
            CourseDaoModel? courseDaoModel = new CourseDaoModel();
            try
            {
                courseDaoModel = (from course in this.context.Course
                                  join depto in this.context.Departments on course.DepartmentId equals depto.DepartmentId

                                  where course.Deleted == false
                                  && course.CourseId == Id
                                  select new CourseDaoModel()
                                  {
                                      CourseId = course.CourseId,
                                      CreationDate = course.CreationDate,

                                      Credits = course.Credits,
                                      DepartmentId = course.DepartmentId,
                                      DepartmentName = depto.Name,
                                      Title = course.Title,
                                  }).FirstOrDefault();




            }
            catch (Exception ex)
            {
                throw new DaoCourseException($"Error obteniendo el curso:{ex.Message}");

            }
            return courseDaoModel;
        }



        public List<CourseDaoModel> GetCourses()
        {

            List<CourseDaoModel>? courseList = new List<CourseDaoModel>();
            try
            {
                courseList = (from course in this.context.Course
                              join depto in this.context.Departments 
                              on course.DepartmentId 
                              equals depto.DepartmentId

                              orderby course.CreationDate descending
                              select new CourseDaoModel()
                              {
                                  CourseId = course.CourseId,
                                  CreationDate = course.CreationDate,

                                  Credits = course.Credits,
                                  DepartmentId = course.DepartmentId,
                                  DepartmentName = depto.Name,
                                  Title = course.Title,
                              }).ToList();

            }

            catch (Exception ex)
            {
                throw new DaoCourseException($"Error obteniendo el curso:{ex.Message}");

            }
            return courseList;
        }

        public List<CourseDaoModel> GetCourses(Func<Course, bool> filter)
        {
            List<CourseDaoModel>? coursesList = new List<CourseDaoModel>();
            try
            {
                var courses = this.context.Course.Where(filter);
                coursesList = (from course in courses
                               join depto in this.context.Departments on course.DepartmentId equals depto.DepartmentId


                               select new CourseDaoModel()
                               {
                                   CourseId = course.CourseId,
                                   CreationDate = course.CreationDate,

                                   Credits = course.Credits,
                                   DepartmentId = course.DepartmentId,
                                   DepartmentName = depto.Name,
                                   Title = course.Title,
                               }).ToList();

            }
            catch (Exception ex)
            {
                throw new DaoCourseException($"Error obteniendo el curso:{ex.Message}");

            }
            return coursesList;
        }

        public void RemoveCourse(Course department)
        {
            throw new NotImplementedException();
        }

        public void SaveCourse(Course Course)
        {
            try
            {
                this.context.Course.Add(Course);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DaoCourseException(ex.Message);
            }
        }

        public void UpdateCourse(Course course)
        {
           
        }

        public void UpdateCourset(Course Course)
        {

            try

            {
                Course? courseToUpdate = this.context.Course.Find(Course.CourseId);
                if (Course is null)

                    throw new DaoCourseException("No se encontró el curso especificado.");

                courseToUpdate.Title = Course.Title;
                courseToUpdate.Credits = Course.Credits;
                courseToUpdate.DepartmentId = Course.DepartmentId;
                courseToUpdate.ModifyDate = DateTime.Now;
                courseToUpdate.UserMod = Course.UserMod;

                this.context.Course.Update(courseToUpdate);
                this.context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new DaoCourseException(ex.Message);

            }

        }
    }
}

       