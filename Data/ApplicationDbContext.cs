using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Siloam.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<Unit> Units { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var unitId1 = Guid.NewGuid();
        var unitId2 = Guid.NewGuid();
        
        modelBuilder.Entity<Vendor>().HasData( 
            new Vendor
            {
                Id = Guid.NewGuid(),
                Name = "Vendor001",
                Address = "Address001",
                UnitId = unitId1
            },
            new Vendor
            {
                Id = Guid.NewGuid(),
                Name = "Vendor002",
                Address = "Address002",
                UnitId = unitId1
            },
            new Vendor
            {
                Id = Guid.NewGuid(),
                Name = "Vendor003",
                Address = "Address003",
                UnitId = unitId1
            },
            new Vendor
            {
                Id = Guid.NewGuid(),
                Name = "Vendor004",
                Address = "Address004",
                UnitId = unitId2
            },
            new Vendor
            {
                Id = Guid.NewGuid(),
                Name = "Vendor005",
                Address = "Address005",
                UnitId = unitId2
            }
        );
        
        modelBuilder.Entity<Unit>().HasData( 
            new Unit
            {
                Id = unitId1,
                Name = "Unit001"
            },
            new Unit
            {
                Id = unitId2,
                Name = "Unit002"
            }
        );
    }
}