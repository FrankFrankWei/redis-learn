using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VoteDemo.Startup))]
namespace VoteDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
