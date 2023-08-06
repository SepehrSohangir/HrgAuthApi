namespace HrgAuthApi.Context;

using HrgAuthApi.Models;
using Microsoft.EntityFrameworkCore;

public class UsersDbContext : DbContext
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserGroups>()
            .HasKey(k => k.GroupCode);
        modelBuilder.Entity<UserGroups>()
            .HasMany(u => u.Users)
            .WithOne(o => o.UserGroup)
            .HasForeignKey(frn => frn.GroupCode)
            .HasPrincipalKey(prm => prm.GroupCode);

        modelBuilder.Entity<Users>()
            .HasKey(usr => new { usr.UserId, usr.CompanyID });

        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Users> Users { get; set; }
    public DbSet<UserGroups> UserGroups { get; set; }
}
