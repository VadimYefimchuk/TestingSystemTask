using System.ComponentModel.DataAnnotations;

namespace TestTask.Models.Tests
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }

        public int? QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
