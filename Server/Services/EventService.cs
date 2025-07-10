namespace GreensProPWA.Server.Services

{
    using GreensProPWA.Shared.Entity;
    using Microsoft.EntityFrameworkCore;

    public class EventDbService
    {
        private readonly AppDbContext _context;

        public EventDbService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Event>> GetAllAsync()
        {
            return await _context.Events.OrderBy(e => e.Date).ToListAsync();
        }

        public async Task<Event?> GetByIdAsync(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task<Event> AddAsync(Event ev)
        {
            _context.Events.Add(ev);
            await _context.SaveChangesAsync();
            return ev;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return false;

            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Event updated)
        {
            var existing = await _context.Events.FindAsync(updated.Id);
            if (existing == null) return false;

            existing.Title = updated.Title;
            existing.Description = updated.Description;
            existing.Date = updated.Date;
            existing.Location = updated.Location;

            await _context.SaveChangesAsync();
            return true;
        }
    }

}
