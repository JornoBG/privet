using Lrmkt.FormsSystem.Entities.Base;

namespace Lrmkt.FormsSystem.Entities
{
    public class Question : Identity
    {
        public string Text { get; set; } = null!;

        public virtual List<Reaction>? Reactions { get; set; }
    }
}