using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Master_Approval_System.Startup))]
namespace Master_Approval_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
