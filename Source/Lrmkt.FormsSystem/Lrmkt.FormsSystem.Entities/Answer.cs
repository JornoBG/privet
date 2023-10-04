using Lrmkt.FormsSystem.Entities.Base;

namespace Lrmkt.FormsSystem.Entities
{
    public class Answer : Identity
    {
        public string UserName { get; set; } = null!;

        public string Feedback { get; set; } = null!;

        public virtual List<Reaction>? Reactions { get; set; }
    }
}