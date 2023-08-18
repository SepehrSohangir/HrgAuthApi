using HrgAuthApi.Models.PublicDbModels;
using Microsoft.EntityFrameworkCore;

namespace HrgAuthApi.Context
{
    public class PublicDbContext : DbContext
    {
        public PublicDbContext(DbContextOptions<PublicDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblMoadianSubSystems_H>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(e => e.MoadianSubSystem)
                .IsRequired();
            });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<TblMoadianSubSystems_H> TblMoadianSubSystems_H { get; set; }
    }
}
