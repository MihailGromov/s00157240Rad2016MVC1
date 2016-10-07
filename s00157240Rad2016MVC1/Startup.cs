using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(s00157240Rad2016MVC1.Startup))]
namespace s00157240Rad2016MVC1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
