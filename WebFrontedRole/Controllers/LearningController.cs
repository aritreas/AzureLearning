using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebFrontedRole.Learning;

namespace WebFrontedRole.Controllers
{
    public class LearningController : ApiController
    {

        private readonly LearningHandler _learningHandler = new LearningHandler();
        // GET learning/username/course
        public async Task<HttpResponseMessage> GetLearningCourse(string username, string course)
        {
            // handle exceptions. Check everywhere!!!
            return _learningHandler.GetPercentCourse(username, course);
        }

        //GET learning/username
        public async Task<HttpResponseMessage> GetLearningCourses(string username)
        {
            return _learningHandler.GetPercentCourses(username);
        }

        // POST learning/<username>
        public async Task<HttpResponseMessage> PostLearning(string username, HttpRequestMessage request)
        {
            MyStaticClass.My();
            return await _learningHandler.UpdateLearningCourses(username, request);
        }

        private static class MyStaticClass
        {
            public static void My()
            {
            }
        }
    }
}