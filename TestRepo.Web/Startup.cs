using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestRepo.Web.Startup))]
namespace TestRepo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
