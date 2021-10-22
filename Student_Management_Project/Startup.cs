using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Student_Management_Project.Startup))]
namespace Student_Management_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
