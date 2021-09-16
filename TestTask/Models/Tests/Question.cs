using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Models.Tests
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public string QuestionText { get; set; }

        public int? TestId { get; set; }

        public Test Test { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
