using Microsoft.EntityFrameworkCore;
using Varejao.Model;

namespace Varejao.Data
{
    public class VarejaoContext : DbContext
    {
        public DbSet<Hortifruti> Hortifruti { get; set; }
        public DbSet<Lote> Lote { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Lote>()
                .HasOne(pv => pv.Hortifruti)
                .WithMany(p => p.Lotes)
                .HasForeignKey(pv => pv.IdHortifruti)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
