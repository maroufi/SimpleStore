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
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer("Data Source=localhost;Initial Catalog=SimpleStore;User id=sa;Password=2760;Integrated Security=True;TrustServerCertificate=True");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(p => p.Id)
                  .ValueGeneratedOnAdd();

            entity.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(40);
            entity.HasIndex(prop => prop.Title, "UIX_Product_Title").IsUnique();

            entity.Property(p => p.InventoryCount)
                .IsRequired();

            entity.Property(p => p.Discount)
                .IsRequired()
                .HasPrecision(5, 2);

            entity.Property(p => p.Price)
                .IsRequired()
                .HasPrecision(18, 0);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(p => p.Id)
                  .ValueGeneratedOnAdd();

            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasData(
                new User
                {
                    Id = 1,
                    Name = "Tom Peters",
                },
                new User
                {
                    Id = 2,
                    Name = "James Clear",
                },
                new User
                {
                    Id = 3,
                    Name = "Adam Grant",
                });
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(p => p.Id)
                  .ValueGeneratedOnAdd();

            entity.Property(p => p.CreationDate)
                .IsRequired();

            entity.HasOne(p => p.Buyer)
                  .WithMany(u => u.Orders)
                  .HasForeignKey(p => p.BuyerId);

            entity.HasOne(p => p.Product)
            .WithMany().HasForeignKey(p => p.ProductId);
        });
    }
}
