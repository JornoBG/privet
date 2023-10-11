using Lrmkt.CourseRatings.Entities.Base;

namespace Lrmkt.CourseRatings.Entities
{
    public class Feedback : Identity
    {
        public string UserName { get; set; } = null!;

        public string Text { get; set; } = null!;
    }
}
