using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Models.Tests
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        public string TestName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public List<Question> Questions { get; set; }
    }
}
