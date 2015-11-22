using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebFrontedRole.Learning;

namespace WebFrontedRole.Test.LearningTest
{
    [TestClass]
    public class UserCoursesTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UserCourses_ShouldThrowException_GivenNullUsername()
        {
            new UserCourses(null, "courses");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UserCourses_ShouldThrowException_GivenNullCourses()
        {
            new UserCourses("username", null);
        }



    }
}
