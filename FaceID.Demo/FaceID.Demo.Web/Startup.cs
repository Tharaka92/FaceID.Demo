using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FaceID.Demo.Web.Startup))]
namespace FaceID.Demo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
