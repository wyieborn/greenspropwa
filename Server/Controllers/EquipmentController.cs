using GreensProPWA.Shared.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreensProPWA.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EquipmentController : ControllerBase
    {
        private readonly AppDbContext _db;

        public EquipmentController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _db.EquipmentType.ToListAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> AddEquipment([FromBody] EquipmentType equipment)
        {
            _db.EquipmentType.Add(equipment);
            await _db.SaveChangesAsync();
            return Ok(equipment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEquipment(int id, [FromBody] EquipmentType updatedEquipment)
        {
            var existing = await _db.EquipmentType.FindAsync(id);
            if (existing == null) return NotFound();

            existing.Name = updatedEquipment.Name;
            await _db.SaveChangesAsync();
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipment(int id)
        {
            var existing = await _db.EquipmentType.FindAsync(id);
            if (existing == null) return NotFound();

            _db.EquipmentType.Remove(existing);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }

}
