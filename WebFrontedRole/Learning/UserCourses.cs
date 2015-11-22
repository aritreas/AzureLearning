using System;

namespace WebFrontedRole.Learning
{
    public class UserCourses
    {
        public string Username { get; private set; }
        public string Courses { get; private set; }

        public UserCourses(string username, string courses)
        {
            if (username == null) throw new ArgumentNullException("username");
            if (courses == null) throw new ArgumentNullException("courses");

            Username =username;
            Courses = courses;
        }
    }
}