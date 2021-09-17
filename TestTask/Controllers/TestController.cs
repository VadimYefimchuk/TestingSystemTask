using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models.TestsDTO;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly Random rnd = new Random();
        private readonly IMapper _mapper;

        public TestController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTests()
        {
            var tests = await _context.Tests
                                      .Include(x => x.Questions)
                                      .ThenInclude(z => z.Answers)
                                      .ToListAsync();
            List<TestDto> mappedList = new List<TestDto>();

            foreach (var dto in tests.OrderBy(x => rnd.Next()).Take(3))
            {
                mappedList.Add(_mapper.Map<TestDto>(dto));
            }

            return Ok(mappedList);
        }

        [HttpPost]
        public async Task<IActionResult> CheckTestsResult(List<AnswerDto> userAnswers)
        {
            var countCorrectAnswer = 0;
            
            foreach(var answer in userAnswers)
            {
                var isCorrect = await _context.Answers.Where(x => x.Id == answer.Id).Select(x => x.IsCorrect).FirstOrDefaultAsync();

                if (isCorrect)
                {
                    countCorrectAnswer++;
                }
            }

            return Ok(countCorrectAnswer == userAnswers.Count());
        }
    }
}