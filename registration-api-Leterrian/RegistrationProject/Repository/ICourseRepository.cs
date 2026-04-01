using CourseRegistration.Models;


namespace CourseRegistration.Repository
{
    public interface ICourseRepository
    {
        List<Course> Courses { get; set; }

        public List<CourseOffering> getOfferingsByGoalIdAndSemester(String theGoalId, String semester);
        public List<Course> GetAllCourses();
        public Course GetCourseByName(string name);
        public void AddCourse(Course course);
        public void UpdateCourse(Course course);
        public void DeleteCourse(string name);
    }
}

