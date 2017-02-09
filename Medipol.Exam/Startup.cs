using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Medipol.Exam.Startup))]
namespace Medipol.Exam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
