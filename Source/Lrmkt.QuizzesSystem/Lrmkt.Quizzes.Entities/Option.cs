using Lrmkt.QuizzesSystem.Entities.Base;

namespace Lrmkt.QuizzesSystem.Entities
{
    public class Option : Identity
    {
        public string Text { get; set; } = null!;

        public int Choices { get; set; }

        public Guid QuestionId { get; set; }

        public Question? Question { get; set; }
    }
}