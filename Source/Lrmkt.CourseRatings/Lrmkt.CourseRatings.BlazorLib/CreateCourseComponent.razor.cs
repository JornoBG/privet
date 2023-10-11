using Lrmkt.CourseRatings.Application;
using Lrmkt.CourseRatings.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.ComponentModel.DataAnnotations;

namespace Lrmkt.CourseRatings.BlazorLib
{
    public class CreateCourseModel : ComponentBase
    {
        [Inject] protected ApplicationDbContext Context { get; set; } = null!;

        [Inject] protected IJSRuntime JsRuntime { get; set; } = null!;

        public List<string> Errors { get; } = new();

        public string? Title { get; set; }

        public List<QuestionInput> Questions { get; set; } = new();

        protected void AddQuestion()
        {
            Questions.Add(new QuestionInput());
        }

        protected void RemoveQuestion(QuestionInput item)
        {
            Questions.Remove(item);
        }

        protected async Task SaveQuiz()
        {
            Validate();
            if (Errors.Any())
            {
                return;
            }

            var questions = Questions.Select(x => new Question { Text = x.Text! }).ToList();

            var course = new Course
            {
                Title = Title!,
                Questions = questions
            };

            Context.Courses.Add(course);
            await Context.SaveChangesAsync();

            Title = null;
            Questions.Clear();

            await JsRuntime.InvokeVoidAsync("alert", "Course added!");
        }

        protected void Validate()
        {
            Errors.Clear();

            var errors = ValidateCourse();

            var validationResults = errors.ToList();
            if (validationResults.Any())
            {
                Errors.AddRange(validationResults.Select(x => x.ErrorMessage).ToList()!);
            }
        }

        private IEnumerable<ValidationResult> ValidateCourse()
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                yield return new ValidationResult("The course title text is not set.");
            }

            if (!string.IsNullOrWhiteSpace(Title) && Title.Length > 100)
            {
                yield return new ValidationResult("The course title must be less than 100 characters long.");
            }

            if (!Questions.Any())
            {
                yield return new ValidationResult("There are no questions.");
                yield break;
            }

            foreach (var question in Questions)
            {
                if (string.IsNullOrWhiteSpace(question.Text))
                {
                    yield return new ValidationResult("No question text.");
                    yield break;
                }

                if (question.Text.Length > 500)
                {
                    yield return new ValidationResult($"\"{question.Text}\" too long. No more than 500 characters allowed.");
                    continue;
                }
            }
        }

        public class QuestionInput
        {
            public string? Text { get; set; }
        }
    }
}
