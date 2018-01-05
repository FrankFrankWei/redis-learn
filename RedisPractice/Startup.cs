using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RedisPractice.Startup))]
namespace RedisPractice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
