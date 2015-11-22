using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebFrontedRole.Learning;

namespace WebFrontedRole.Test.LearningTest
{
    [TestClass]
    public class CourseEntityTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseEntity_ShouldThrowException_GivenNullUsername()
        {
            new CoursesEntity(null, "course", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseEntity_ShouldThrowException_GivenNullCourse()
        {
            new CoursesEntity("username", null, 10);
        }
    }
}
