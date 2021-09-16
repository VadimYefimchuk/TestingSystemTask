using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models.Tests;
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

            return Ok(tests.OrderBy(x => rnd.Next()).Take(3));
        }
    }
}