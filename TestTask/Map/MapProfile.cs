using AutoMapper;
using TestTask.Models.Tests;
using TestTask.Models.TestsDTO;

namespace TestTask.Map
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<Test, TestDto>();
            CreateMap<Question, QuestionDto>();
            CreateMap<Answer, AnswerDto>();
        }
    }
}