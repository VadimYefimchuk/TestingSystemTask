using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTask.Data;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly Random rnd = new Random();

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTests()
        {
            var tests = await _context.Tests
                                      .Include(x => x.Questions)
                                      .ThenInclude(z => z.Answers)
                                      .ToListAsync();

            return Ok(tests.OrderBy(x => rnd.Next())
                           .Take(3));
        }
    }
}