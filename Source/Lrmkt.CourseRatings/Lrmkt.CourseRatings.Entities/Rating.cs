using Lrmkt.CourseRatings.Entities.Base;

namespace Lrmkt.CourseRatings.Entities
{
    public class Rating : Identity
    {
        public int Value { get; set; }

        public Guid QuestionId { get; set; }

        public Question? Question { get; set; }
    }
}