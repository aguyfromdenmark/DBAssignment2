using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DBAssignment2.Startup))]
namespace DBAssignment2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
