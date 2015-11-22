using System.Net;
using System.Net.Http;
using System.Text;

namespace WebFrontedRole.Learning
{
    // rename to Factory
    public class GetResponses
    {
        public HttpResponseMessage CreateHttpOkCourses(UserCourses userCourses)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(userCourses.Courses, Encoding.UTF8, "application/json")
            };
        }

        public HttpResponseMessage CreateHttpOk()
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage CreateHttpNotFound()
        {
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage CreateHttpBadRequest()
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}