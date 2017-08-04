using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormsExam.Web.Startup))]
namespace WebFormsExam.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
