using Microsoft.EntityFrameworkCore;
using Projekt.Models.Films;
using Projekt.Models.Rents;
using Projekt.Models.Users;

namespace Projekt.Context
{
    public class FilmContext : DbContext
    {
        public FilmContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<FilmsModel> Films { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RentsModel> Rents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
