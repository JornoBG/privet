using Lrmkt.CourseRatings.Application;
using Lrmkt.CourseRatings.Web.Definitions.Base;
using Microsoft.EntityFrameworkCore;

namespace Lrmkt.CourseRatings.Web.Definitions.DbContext
{
    public class DbContextDefinition : AppDefinition
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(nameof(ApplicationDbContext)));
            });
        }
    }
}
