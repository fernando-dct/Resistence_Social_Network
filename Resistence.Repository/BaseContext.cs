using Microsoft.EntityFrameworkCore;
using Resistence_Entity;

namespace Resistence_Repository
{
    public class BaseContext(DbContextOptions<BaseContext> options) : DbContext(options)
    {
        public DbSet<Local> Locais { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Rebelde> Rebeldes { get; set; }
        public DbSet<Item> Itens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rebelde>().HasKey(x => x.IdRebelde);
            modelBuilder.Entity<Local>().HasKey(x => x.IdLocal);
            modelBuilder.Entity<Local>().HasOne(x => x.Rebelde).WithOne(y => y.Local).HasForeignKey<Local>(z => z.IdRebelde);
            modelBuilder.Entity<Item>().HasKey(x => x.IdItem);
            modelBuilder.Entity<Inventario>().HasKey(x => x.IdInventario);
            modelBuilder.Entity<Inventario>().HasOne(x => x.Rebelde).WithMany(y => y.Inventario).HasForeignKey(z => z.IdRebelde).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
