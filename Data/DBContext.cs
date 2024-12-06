using asp_test.Models;
using Microsoft.EntityFrameworkCore;

namespace asp_test.Data
{
  public class DBContext : DbContext
  {
    public DBContext(DbContextOptions<DBContext> options) : base(options) { }

    public DbSet<Player> Players => Set<Player>();
    public DbSet<Club> Clubs => Set<Club>();
    public DbSet<Banner> Banners => Set<Banner>();
    public DbSet<Tournament> Tournaments => Set<Tournament>();
    public DbSet<Game> Games => Set<Game>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Player>(e =>
      {
        e.HasKey(e => e.Id);
      });

      modelBuilder.Entity<Club>(e =>
      {
        e.HasKey(e => e.Id);
      });

      modelBuilder.Entity<Banner>(e =>
      {
        e.HasKey(e => e.Id);
        e.HasOne(e => e.Club1).WithMany(e => e.Banners1).HasForeignKey(e => e.Club1Id);
        e.HasOne(e => e.Club2).WithMany(e => e.Banners2).HasForeignKey(e => e.Club2Id);
      });

      modelBuilder.Entity<Tournament>(e =>
      {
        e.HasKey(e => e.Id);
      });

      modelBuilder.Entity<Game>(e =>
      {
        e.HasKey(e => e.Id);
        e.HasOne(e => e.Tournament).WithMany(e => e.Games).HasForeignKey(e => e.TournamentId);
        e.HasOne(e => e.Club1).WithMany(e => e.Games1).HasForeignKey(e => e.Club1Id);
        e.HasOne(e => e.Club2).WithMany(e => e.Games2).HasForeignKey(e => e.Club2Id);
      });
    }
  }
}