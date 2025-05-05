using Microsoft.EntityFrameworkCore;
using LocadoraApi.Models;
using LocadoraApi.Mappings;

namespace BellaDriveApi
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Carro> Carros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarroConfiguration());
        }
    }
}