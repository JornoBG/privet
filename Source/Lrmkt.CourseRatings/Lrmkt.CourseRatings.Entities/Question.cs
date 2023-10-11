using Lrmkt.CourseRatings.Entities.Base;

namespace Lrmkt.CourseRatings.Entities
{
    public class Question : Identity
    {
        public string Text { get; set; } = null!;

        public Guid CourseId { get; set; }

        public Course? Course { get; set; }

        public List<Rating>? Raitings { get; set; }
    }
}