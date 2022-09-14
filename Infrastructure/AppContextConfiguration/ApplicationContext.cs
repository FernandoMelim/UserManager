using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.AppContextConfiguration;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
     : base(options)
    { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseIdentityColumns();
        modelBuilder.HasDefaultSchema("UserManager");
        modelBuilder.Entity<User>().ToTable("User");
        ConfigureUserEntity(modelBuilder);
    }

    private void ConfigureUserEntity(ModelBuilder construtorDeModelos)
    {
        construtorDeModelos.Entity<User>(etd =>
        {
            etd.ToTable("Users");
            etd.HasKey(c => c.Id).HasName("Id");
            etd.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            etd.Property(c => c.Name).HasColumnName("Name").HasMaxLength(255);
            etd.Property(c => c.Surname).HasColumnName("Surname").HasMaxLength(255);
            etd.Property(c => c.Email).HasColumnName("Email").HasMaxLength(255);
            etd.Property(c => c.SchoolingLevel).HasColumnName("SchoolingLevel");
            etd.Property(c => c.BirthDate).HasColumnName("BirthDate");
        });
    }
}

