using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using Owin;

namespace WebFrontedRole
{
    public class HttpConfig
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "AzureLearningController",
                routeTemplate: "learning/{username}/{course}",
                defaults: new {Controller = "Learning"},
                constraints: new {httpMethod = new HttpMethodConstraint(HttpMethod.Get)});


            config.Routes.MapHttpRoute(
                name: "GetCourses",
                routeTemplate: "learning/{username}",
                defaults: new {Controller = "Learning"});

            app.UseWebApi(config);
        }
    }
}
