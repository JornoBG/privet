using Lrmkt.QuizzesSystem.Application;
using Lrmkt.QuizzesSystem.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.ComponentModel.DataAnnotations;

namespace Lrmkt.QuizzesSystem.BlazorLib
{
    public class CreateQuizModel : ComponentBase
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

        protected void RemoveQuestion(QuestionInput questionInput)
        {
            Questions.Remove(questionInput);
        }

        protected void AddOption(QuestionInput questionInput)
        {
            questionInput.Options.Add(new OptionInput());
        }

        protected void RemoveOption(QuestionInput questionInput, OptionInput optionInput)
        {
            questionInput.Options.Remove(optionInput);
        }

        protected async Task SaveQuiz()
        {
            Validate();
            if (Errors.Any())
            {
                return;
            }

            var questions = Questions.Select(x => {
                var options = x.Options.Select(x => new Option { Text = x.Text! }).ToList();
                return new Question { Text = x.Text!, Options = options };
            }).ToList();

            var quiz = new Quiz
            {
                Title = Title!,
                Questions = questions
            };

            Context.Quizzes.Add(quiz);
            await Context.SaveChangesAsync();

            Title = null;
            Questions.Clear();

            await JsRuntime.InvokeVoidAsync("alert", "Quiz added!");
        }

        protected void Validate()
        {
            Errors.Clear();

            var errors = ValidateQuiz();

            var validationResults = errors.ToList();
            if (validationResults.Any())
            {
                Errors.AddRange(validationResults.Select(x => x.ErrorMessage).ToList()!);
            }
        }

        private IEnumerable<ValidationResult> ValidateQuiz()
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                yield return new ValidationResult("The quiz title text is not set.");
            }

            if (!string.IsNullOrWhiteSpace(Title) && Title.Length > 100)
            {
                yield return new ValidationResult("The quiz title must be less than 100 characters long.");
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
                    continue;
                }

                if (question.Text.Length > 500)
                {
                    yield return new ValidationResult($"\"{question.Text}\" too long. No more than 500 characters allowed.");
                    continue;
                }

                if (!question.Options.Any())
                {
                    yield return new ValidationResult($"There are no answer options for the question \"{question.Text}\".");
                    continue;
                }

                foreach (var option in question.Options)
                {
                    if (string.IsNullOrWhiteSpace(option.Text))
                    {
                        yield return new ValidationResult("The answer option text is not set.");
                        continue;
                    }

                    if (option.Text.Length > 100)
                    {
                        yield return new ValidationResult($"\"{option.Text}\" too long. No more than 100 characters allowed.");
                    }
                }
            }
        }

        public class QuestionInput
        {
            public string? Text { get; set; }

            public List<OptionInput> Options { get; set; } = new()
            {
                new OptionInput { Text = "💀" },
                new OptionInput { Text = "😄" }
            };
        }

        public class OptionInput
        {
            public string? Text { get; set; }
        }
    }
}
