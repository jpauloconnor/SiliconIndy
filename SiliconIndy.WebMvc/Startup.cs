using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SiliconIndy.WebMvc.Startup))]
namespace SiliconIndy.WebMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
