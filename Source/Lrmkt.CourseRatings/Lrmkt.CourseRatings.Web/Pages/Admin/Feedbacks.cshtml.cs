using Lrmkt.CourseRatings.Application;
using Lrmkt.CourseRatings.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lrmkt.CourseRatings.Web.Pages.Admin
{
    public class FeedbacksModel : PageModel
    {
        public List<Feedback> Feedbacks { get; set; } = new();

        private ApplicationDbContext _context;

        public FeedbacksModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Feedbacks = _context.Feedbacks.ToList();
        }
    }
}
