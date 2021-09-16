using System.Collections.Generic;

namespace TestTask.Models.TestsDTO
{
    public class QuestionDto
    {
        public int Id { get; set; }

        public string QuestionText { get; set; }

        public int? TestId { get; set; }

        public List<AnswerDto> Answers { get; set; }
    }
}
