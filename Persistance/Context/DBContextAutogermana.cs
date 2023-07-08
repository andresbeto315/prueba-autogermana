using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Context
{
    public sealed class DBContextAutogermana : DbContext
    {
        public DBContextAutogermana(DbContextOptions<DBContextAutogermana> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CategoryEntity> categoria { get; set; }
        public DbSet<ProductEntity> product { get; set; }
    }
}