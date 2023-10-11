using Lrmkt.CourseRatings.Entities.Base;

namespace Lrmkt.CourseRatings.Entities
{
    public class Course : Identity
    {
        public string Title { get; set; } = null!;

        public List<Question>? Questions { get; set; }
    }
}
