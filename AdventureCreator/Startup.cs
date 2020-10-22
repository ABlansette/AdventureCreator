using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdventureCreator.Startup))]
namespace AdventureCreator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
