using Microsoft.EntityFrameworkCore;

namespace Practica1.Context
{
    public class Ctxtdb:DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder buildier)
        {
            buildier.UseMySQL("server=localhost;database=animales;user=clases;password=123456");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MODEL>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name);
                entity.Property(e => e.Description);
                entity.Property(e => e.Family);
                entity.HasOne(e => e.Zone).WithMany(p => p.Animales);
            });
        }
    }
}
