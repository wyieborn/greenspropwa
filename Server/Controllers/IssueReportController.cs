using GreensProPWA.Shared.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreensProPWA.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssueReportsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IssueReportsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<IssueReport>>> GetAll()
        {
            return await _context.IssueReports.OrderByDescending(r => r.CreatedAt).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<IssueReport>> Create(IssueReport report)
        {
            _context.IssueReports.Add(report);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = report.Id }, report);
        }
    }

}
