using Lrmkt.QuizzesSystem.Entities.Base;

namespace Lrmkt.QuizzesSystem.Entities
{
    public class Question : Identity
    {
        public string Text { get; set; } = null!;

        public Guid QuizId { get; set; }

        public Quiz? Quiz { get; set; }

        public List<Option>? Options { get; set; }
    }
}