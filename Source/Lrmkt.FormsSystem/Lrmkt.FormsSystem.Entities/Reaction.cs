using Lrmkt.FormsSystem.Entities.Base;

namespace Lrmkt.FormsSystem.Entities
{
    public class Reaction : Identity
    {
        public char Symbol { get; set; }

        public virtual Question? Question { get; set; }
    }
}