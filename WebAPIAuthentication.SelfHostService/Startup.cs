using System;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Owin;

namespace WebAPIAuthentication.SelfHostService
{
    public class Startup
    {
        // This method is required by Katana:
        public void Configuration(IAppBuilder app)
        {
            var webApiConfiguration = ConfigureWebApi();

            // Use the extension method provided by the WebApi.Owin library:
            app.UseWebApi(webApiConfiguration);
        }

        private HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{name}",
                new { name = RouteParameter.Optional });
            return config;
        }
    }
}
