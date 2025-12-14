using Microsoft.EntityFrameworkCore;

namespace TaskRPG.API.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Core.Models.Equipment> Equipment { get; set; }
    public DbSet<Core.Models.PlayerData> PlayerData { get; set; }
    public DbSet<Core.Models.ShopEquipment> ShopEquipments { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Core.Models.PlayerData>()
            .HasKey(p => p.Id);
        
        modelBuilder.Entity<Core.Models.PlayerData>()
            .Ignore(p => p.StatList)
            .Ignore(p => p.InventoryList);
        
        modelBuilder.Entity<Core.Models.Equipment>()
            .HasKey(e => e.Id);
        
        modelBuilder.Entity<Core.Models.Equipment>()
            .Ignore(e => e.StatBuffs);
        
        modelBuilder.Entity<Core.Models.ShopEquipment>()
            .HasKey(e => e.Id);
        
        modelBuilder.Entity<Core.Models.ShopEquipment>()
            .Ignore(e => e.StatBuffs);

        modelBuilder.Entity<Core.Models.Stat>()
            .HasNoKey();
    }
}