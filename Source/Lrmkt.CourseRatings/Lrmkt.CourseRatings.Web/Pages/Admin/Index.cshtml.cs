using Lrmkt.CourseRatings.Application;
using Lrmkt.CourseRatings.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lrmkt.CourseRatings.Web.Pages.Admin
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public List<Course> Courses { get; set; } = null!;

        private ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Courses = _context.Courses.ToList();
        }
    }
}
