using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Assignment1_v3.Models;

namespace Assignment1_v3.Data;

public class ApplicationDbContext : IdentityDbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Resolution>()
            .Property(s => s.CreationDate)
            .HasDefaultValueSql("GETDATE()");

        // Use seed method here
        builder.Seed();
    }

    public DbSet<Assignment1_v3.Models.Resolution>? Resolutions { get; set; }

    public DbSet<Assignment1_v3.Models.ApplicationUser>? ApplicationUsers { get; set; }

    public DbSet<Assignment1_v3.Models.Feedback>? Feedbacks { get; set; }

}
