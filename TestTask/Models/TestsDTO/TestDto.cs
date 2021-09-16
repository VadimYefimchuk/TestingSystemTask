using System.Collections.Generic;

namespace TestTask.Models.TestsDTO
{
    public class TestDto
    {
        public string TestName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public List<QuestionDto> Questions { get; set; }
    }
}