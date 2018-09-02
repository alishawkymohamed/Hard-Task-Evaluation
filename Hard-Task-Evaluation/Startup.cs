using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hard_Task_Evaluation.Startup))]
namespace Hard_Task_Evaluation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
