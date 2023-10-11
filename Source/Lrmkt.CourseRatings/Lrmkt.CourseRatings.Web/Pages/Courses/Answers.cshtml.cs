using Lrmkt.CourseRatings.Application;
using Lrmkt.CourseRatings.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lrmkt.CourseRatings.Web.Pages.Courses
{
    public class AnswersModel : PageModel
    {
        public Course? Course { get; set; }

        private ApplicationDbContext _context;

        public AnswersModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(Guid id)
        {
            Course = _context.Courses
                .Include(x => x.Questions)!
                    .ThenInclude(x => x.Raitings)
                .FirstOrDefault(x => x.Id == id);
            if (Course == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
