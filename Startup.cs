using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sajt.Startup))]
namespace Sajt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            ConfigureAuth(app);
            
        }
       
    }
}
