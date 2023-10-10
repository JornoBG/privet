using Lrmkt.QuizzesSystem.Application;
using Lrmkt.QuizzesSystem.Web.Definitions.Base;
using Microsoft.EntityFrameworkCore;

namespace Lrmkt.QuizzesSystem.Web.Definitions.DbContext
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
