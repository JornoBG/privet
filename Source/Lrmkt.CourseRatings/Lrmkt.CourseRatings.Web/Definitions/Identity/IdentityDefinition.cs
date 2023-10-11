using Lrmkt.CourseRatings.Web.Definitions.Base;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Lrmkt.CourseRatings.Web.Definitions.Identity
{
    public class IdentityDefinition : AppDefinition
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(config =>
                {
                    config.LoginPath = "/admin/login";
                });
        }
    }
}
