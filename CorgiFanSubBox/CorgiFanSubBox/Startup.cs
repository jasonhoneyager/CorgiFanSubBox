using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CorgiFanSubBox.Startup))]
namespace CorgiFanSubBox
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
