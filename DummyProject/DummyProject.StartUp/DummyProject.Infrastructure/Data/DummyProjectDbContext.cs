using DummyProject.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DummyProject.Infrastructure.Data
{
    public class DummyProjectDbContext : DbContext
    {
        public DummyProjectDbContext(DbContextOptions<DummyProjectDbContext> options)
             : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CategoryProduct> CategoryProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TotalAmount).IsRequired();
                entity.Property(e => e.OrderDate).IsRequired();

                entity.HasMany(e => e.OrderItems)
                      .WithOne(e => e.Order)
                      .HasForeignKey(e => e.OrderId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UnitPrice).IsRequired();
                entity.Property(e => e.Quantity).IsRequired();
            });

            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.HasKey(x => new { x.ProductId, x.CategoryId });
                entity.HasOne(x => x.Product)
                .WithMany(x => x.CategoryProduct)
                .HasForeignKey(x => x.ProductId);

                entity.HasOne(x => x.Category)
                .WithMany(x => x.CategoryProduct)
                .HasForeignKey(x => x.CategoryId);
            });
        }
    }
}
