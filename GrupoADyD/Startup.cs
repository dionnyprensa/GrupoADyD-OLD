using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GrupoADyD.Startup))]

namespace GrupoADyD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}