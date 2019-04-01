using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_31161021458_NguyenTuQuyen.Startup))]
namespace _31161021458_NguyenTuQuyen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
