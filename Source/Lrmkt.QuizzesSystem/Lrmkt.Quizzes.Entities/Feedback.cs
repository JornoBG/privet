using Lrmkt.QuizzesSystem.Entities.Base;

namespace Lrmkt.QuizzesSystem.Entities
{
    public class Feedback : Identity
    {
        public string UserName { get; set; } = null!;

        public string Text { get; set; } = null!;

        public Guid QuizId { get; set; }

        public Quiz? Quiz { get; set; }
    }
}
