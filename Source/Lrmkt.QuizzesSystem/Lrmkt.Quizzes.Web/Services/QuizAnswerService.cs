using Lrmkt.QuizzesSystem.Application;
using Lrmkt.QuizzesSystem.Entities;

namespace Lrmkt.QuizzesSystem.Web.Services
{
    // Желательно обновить эту штуку
    public class QuizAnswerService
    {
        private ApplicationDbContext _context;

        public QuizAnswerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Answer(Quiz quiz, List<Option> options, Feedback feedback)
        {
            quiz.Answers += 1;

            foreach (var question in quiz.Questions!)
            {
                var option = options.FirstOrDefault(x => x.Question == question);
                if (option == null)
                {
                    return;
                }

                option.Choices += 1;

                _context.Options.Update(option);
            }

            quiz.Feedbacks!.Add(feedback);

            _context.Quizzes.Update(quiz);
            await _context.SaveChangesAsync();
        }
    }
}
