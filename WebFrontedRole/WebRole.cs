using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.Owin.Hosting;

namespace WebFrontedRole
{
    public class WebRole : RoleEntryPoint
    {
        private IDisposable _app;
        public override void Run()
        {
            // 
            while (true)
            {
                //change to await Task.Delay(100). 
                Thread.Sleep(10000);
            }
        }
        public override bool OnStart()
        {
            var endpoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["HttpEndpoint"];
            var baseUrl = String.Format("{0}://{1}", endpoint.Protocol, endpoint.IPEndpoint);
//            _app = WebApp.Start<HttpConfig>(new StartOptions(baseUrl));
            _app = WebApp.Start<HttpConfig>(baseUrl);
            return base.OnStart();
        }

        public override void OnStop()
        {
            if (_app != null)
                _app.Dispose();
            
            base.OnStop();
        }
    }
}
