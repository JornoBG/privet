using Lrmkt.QuizzesSystem.Entities.Base;

namespace Lrmkt.QuizzesSystem.Entities
{
    public class Quiz : Identity
    {
        public string Title { get; set; } = null!;

        public int Answers { get; set; }

        public List<Question>? Questions { get; set; }

        public List<Feedback>? Feedbacks { get; set; }
    }
}
