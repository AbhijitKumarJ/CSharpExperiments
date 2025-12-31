using Microsoft.EntityFrameworkCore;
using WebApp3.Models;

namespace WebApp3.Data;

public class DvdRentalContext : DbContext
{
    public DvdRentalContext(DbContextOptions<DvdRentalContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("customer");
            entity.HasKey(e => e.CustomerId);
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.StoreId).HasColumnName("store_id").HasColumnType("smallint");
            entity.Property(e => e.FirstName).HasColumnName("first_name").HasMaxLength(45);
            entity.Property(e => e.LastName).HasColumnName("last_name").HasMaxLength(45);
            entity.Property(e => e.Email).HasColumnName("email").HasMaxLength(50);
            entity.Property(e => e.AddressId).HasColumnName("address_id").HasColumnType("smallint");
            entity.Property(e => e.ActiveBool).HasColumnName("activebool");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("date");
            entity.Property(e => e.LastUpdate).HasColumnName("last_update").HasColumnType("timestamp without time zone");
        });
    }
}
