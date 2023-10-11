using Lrmkt.CourseRatings.Application;
using Lrmkt.CourseRatings.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lrmkt.CourseRatings.Web.Pages.Courses
{
    public class RemoveModel : PageModel
    {
        public Course? Quiz { get; set; }

        private ApplicationDbContext _context;

        public RemoveModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(Guid id)
        {
            Quiz = _context.Courses.Find(id);
            if (Quiz == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(Guid id)
        {
            Quiz = _context.Courses.Find(id);
            if (Quiz == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(Quiz);
            await _context.SaveChangesAsync();

            return Redirect("/Admin/Index");
        }
    }
}
