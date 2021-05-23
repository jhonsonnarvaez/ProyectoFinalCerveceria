using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoFinalCerveceria.Startup))]
namespace ProyectoFinalCerveceria
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
