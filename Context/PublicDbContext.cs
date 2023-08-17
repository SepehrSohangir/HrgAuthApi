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
            base.OnModelCreating(modelBuilder);
        }
    }
}
