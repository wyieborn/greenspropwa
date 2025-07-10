using GreensProPWA.Shared.DTO;
using GreensProPWA.Shared.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreensProPWA.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public TrainingsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet("trainers")]
        public async Task<IActionResult> GetTrainers()
        {
            var trainers = await _db.Users
                .Where(u => u.IsTrainer)
                .Select(u => new TrainerDto { Id = u.Id, Name = u.FullName })
                .ToListAsync();

            return Ok(trainers);
        }

        [HttpPost]
        public async Task<IActionResult> PostTraining(Training record)
        {
            record.TrainingDate = record.TrainingDate.ToUniversalTime();
            _db.Trainings.Add(record);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _db.Trainings.ToListAsync();
            return Ok(list);
        }
    }
}
