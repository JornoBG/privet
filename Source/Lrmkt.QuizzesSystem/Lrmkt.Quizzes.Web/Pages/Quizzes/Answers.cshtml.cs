using Lrmkt.QuizzesSystem.Application;
using Lrmkt.QuizzesSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lrmkt.QuizzesSystem.Web.Pages.Quizzes
{
    public class AnswersModel : PageModel
    {
        public Quiz? Quiz { get; set; }

        private ApplicationDbContext _context;

        public AnswersModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(Guid id)
        {
            Quiz = _context.Quizzes
                .Include(x => x.Questions)!
                    .ThenInclude(x => x.Options)
                .Include(x => x.Feedbacks)
                .FirstOrDefault(x => x.Id == id);
            if (Quiz == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
