using Lrmkt.QuizzesSystem.Application;
using Lrmkt.QuizzesSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lrmkt.QuizzesSystem.Web.Pages.Quizzes
{
    public class RemoveModel : PageModel
    {
        public Quiz? Quiz { get; set; }

        private ApplicationDbContext _context;

        public RemoveModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(Guid id)
        {
            Quiz = _context.Quizzes.Find(id);
            if (Quiz == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(Guid id)
        {
            Quiz = _context.Quizzes.Find(id);
            if (Quiz == null)
            {
                return NotFound();
            }

            _context.Quizzes.Remove(Quiz);
            await _context.SaveChangesAsync();

            return Redirect("/Admin/Index");
        }
    }
}
