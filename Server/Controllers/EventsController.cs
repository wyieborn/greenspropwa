//using GreensProPWA.Server.Data;
using GreensProPWA.Shared.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly AppDbContext _context;

    public EventsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
    {
        return await _context.Events.ToListAsync();
    }

    [HttpPost]
    public async Task<IActionResult> CreateEvent(Event evt)
    {
        _context.Events.Add(evt);
        await _context.SaveChangesAsync();
        return Ok(evt);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvent(int id, Event evt)
    {
        if (id != evt.Id) return BadRequest();
        _context.Entry(evt).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        var evt = await _context.Events.FindAsync(id);
        if (evt == null) return NotFound();
        _context.Events.Remove(evt);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
