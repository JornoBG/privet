using Lrmkt.QuizzesSystem.Web.Definitions.Base;

namespace Lrmkt.QuizzesSystem.Web.Definitions.Blazor
{
    public class BlazorDefinition : AppDefinition
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddServerSideBlazor();
        }

        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
        {
            app.MapBlazorHub();
        }
    }
}
