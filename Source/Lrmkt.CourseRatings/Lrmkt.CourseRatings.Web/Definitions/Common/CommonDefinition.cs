﻿using Lrmkt.CourseRatings.Web.Definitions.Base;

namespace Lrmkt.CourseRatings.Web.Definitions.Common
{
    public class CommonDefinition : AppDefinition
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddRazorPages();
        }

        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

        }
    }
}
