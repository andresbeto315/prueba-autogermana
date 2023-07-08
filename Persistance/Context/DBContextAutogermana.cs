using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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
            modelBuilder.Entity<CategoryEntity>(c =>
            {
                c.HasKey("idcategoria");
            });

            modelBuilder.Entity<ProductEntity>(c =>
            {
                c.HasKey("idproducto");
            });
        }

        public DbSet<CategoryEntity> categoria { get; set; }
        public DbSet<ProductEntity> producto { get; set; }
    }
}