using System;
using System.Collections.Generic;
using CourseRegistration.Models;
using MySql.Data.MySqlClient;

namespace CourseRegistration.Repository
{
    public class CourseRepository : ICourseRepository
    {
        // obsolete, delete soon
        public List<Course> Courses { get; set; }
        public List<CoreGoal> Goals { get; set; }
        public List<CourseOffering> Offerings { get; set; }

        


        private MySqlConnection _connection;

        //Add more data as needed 
        public CourseRepository()
        {
            string connectionString = "server=localhost;userid=csci330user;password=csci330pass;database=CourseRegistration";
            _connection = new MySqlConnection(connectionString);
            _connection.Open();

            Courses = new List<Course>();
            Goals = new List<CoreGoal>();
            Offerings = new List<CourseOffering>();

        }//end constructor

        ~CourseRepository()
        {
            _connection.Close();
        }

        public IEnumerable<Course> GetAll()
        {
            var statement = "Select * from Courses";
            var command = new MySqlCommand(statement, _connection);
            var results = command.ExecuteReader();

            List<Course> newList = new List<Course>(25);

            while (results.Read())
            {
                Course c = new Course
                {
                    Name = (string)results[0],
                    Title = (string)results[1],
                    Credits = (double)results[2],
                    Description = (string)results[3]
                };
                newList.Add(c);
            }
            results.Close();
            return newList;

        }

        public List<Course> GetAllCourses()
        {
            return GetAll().ToList();
        }

        public Course GetCourseByName(string name)
        {
            var statement = $"Select * from Courses where Name=@newName";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@newName", name);
            var results = command.ExecuteReader();

            if (results.Read())
            {
                Course c = new Course
                {
                    Name = (string)results[0],
                    Title = (string)results[1],
                    Credits = (double)results[2],
                    Description = (string)results[3]
                };
                results.Close();
                return c;
            }
            results.Close();
            return null;

        }

        public Course InsertCourse(Course newCourse)
        {
            var statement = "INSERT into Courses (Name, Title, Credits, Description) values (@newName, @newTitle, @newCredits, @ewDescription)";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@newName", newCourse.Name);
            command.Parameters.AddWithValue("@newTitle", newCourse.Title);
            command.Parameters.AddWithValue("@newCredits", newCourse.Credits);
            command.Parameters.AddWithValue("@ewDescription", newCourse.Description);

            int result = command.ExecuteNonQuery();
            if (result == 1)
                return newCourse;
            else
                return null;
        }

        public List<CourseOffering> getOfferingsByGoalIdAndSemester(string theGoalId, string semester)
        {
            return new List<CourseOffering>();
        }

        public void AddCourse(Course course)
        {
            throw new NotImplementedException();
        }
        
        public void UpdateCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public void DeleteCourse(string name)
        {
            throw new NotImplementedException();
        }    


            
    }
}
