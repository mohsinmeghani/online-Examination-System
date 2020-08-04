using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Online_Examination_System.Startup))]
namespace Online_Examination_System
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
