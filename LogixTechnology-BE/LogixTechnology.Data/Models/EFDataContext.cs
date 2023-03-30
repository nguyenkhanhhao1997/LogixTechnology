using Microsoft.EntityFrameworkCore;


namespace LogixTechnology.Data.Models
{
    public class EFDataContext : DbContext
    {
        public EFDataContext(DbContextOptions<EFDataContext> options)
         : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserActivity>().HasKey(s => new { s.UserId, s.MovieId });
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<UserActivity> UserActivites { get; set; }
    }
}
