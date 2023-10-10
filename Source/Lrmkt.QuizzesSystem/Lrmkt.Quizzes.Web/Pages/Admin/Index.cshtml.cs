using Lrmkt.QuizzesSystem.Application;
using Lrmkt.QuizzesSystem.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lrmkt.QuizzesSystem.Web.Pages.Admin
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public List<Quiz> Quizzes { get; set; } = null!;

        private ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Quizzes = _context.Quizzes
                .Include(x => x.Feedbacks)
                .ToList();
        }
    }
}
