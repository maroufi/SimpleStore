using Microsoft.EntityFrameworkCore;
using SimpleStore.App.Data.Models;

namespace SimpleStore.App.Data;

public class SimpleStoreDbContext : DbContext
{
    public SimpleStoreDbContext(DbContextOptions<SimpleStoreDbContext> options)
    : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer("Data Source=localhost;Initial Catalog=SimpleStore;User id=sa;Password=2760;Integrated Security=True;TrustServerCertificate=True");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(p=>p.Id)
                  .ValueGeneratedOnAdd();

            entity.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(40);
            entity.HasIndex(prop => prop.Title, "UIX_Product_Title").IsUnique();

            entity.Property(p => p.InventoryCount)
                .IsRequired();

            entity.Property(p => p.Discount)
                .IsRequired()
                .HasPrecision(4, 2);

            entity.Property(p => p.Price)
                .IsRequired()
                .HasPrecision(18, 0);
        });



    }
}
