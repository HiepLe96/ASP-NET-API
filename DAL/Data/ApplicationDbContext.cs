
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
            .Entity<Actuals>(
            a =>
            {
                a.HasNoKey();

            });

            modelBuilder
            .Entity<Estimates>(
            a =>
            {
                a.HasNoKey();

            });
        }
        public DbSet<Actuals> Actuals { get; set; }
        public DbSet<Estimates> Estimates { get; set; }
    }
}
