using CourseRegistration.Models;
using CourseRegistration.Repository;


namespace CourseRegistration.Services
{
    public interface ICourseServices
    {
        //public List<CourseOffering> getOfferingsByGoalIdAndSemester(String theGoalId, String semester);
        public List<Course> GetAllCourses();
        public Course GetCourseByName(string name);
        public Course AddCourse(Course course);
        //public void UpdateCourse(Course course);
        //public void DeleteCourse(string name);


    }
}