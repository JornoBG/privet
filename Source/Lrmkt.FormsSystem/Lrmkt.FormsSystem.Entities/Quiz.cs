using Lrmkt.FormsSystem.Entities.Base;

namespace Lrmkt.FormsSystem.Entities
{
    public class Quiz : Identity
    {
        public string Title { get; set; } = null!;

        public virtual List<Question>? Questions { get; set; }

        public virtual List<Answer>? Answers { get; set; }
    }
}
