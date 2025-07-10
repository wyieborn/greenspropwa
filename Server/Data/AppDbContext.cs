using GreensProPWA.Shared.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<IdentityUser> // or ApplicationUser
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Identity requires this

        modelBuilder.Entity<Event>().HasData(
            new Event
            {
                Id = 1,
                Title = "Opening Ceremony",
                Description = "Welcome event for all staffs.",
                Location = "Main Hall",
                Date = DateTime.SpecifyKind(new DateTime(2025, 7, 8), DateTimeKind.Utc)
            },
            new Event
            {
                Id = 2,
                Title = "Summer BBQ",
                Description = "Fun and food with friends and family.",
                Location = "Club Lawn",
                Date = DateTime.SpecifyKind(new DateTime(2025, 7, 14), DateTimeKind.Utc)
            }
        );
    }

    public DbSet<Event> Events => Set<Event>();
    // Only keep this if it's not conflicting with IdentityUser
    public DbSet<User> Users { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<EquipmentType> EquipmentType { get; set; }
    public DbSet<IssueReport> IssueReports { get; set; }





}
