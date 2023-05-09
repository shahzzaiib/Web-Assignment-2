using Microsoft.EntityFrameworkCore;

public class PaintballDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PaintballDb;Trusted_Connection=True;");
    }
}

