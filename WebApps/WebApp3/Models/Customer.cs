using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp3.Models;

[Table("customer")]
public class Customer
{
    [Key]
    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("store_id")]
    public short StoreId { get; set; }

    [Column("first_name")]
    [MaxLength(45)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [MaxLength(45)]
    public string LastName { get; set; } = null!;

    [Column("email")]
    [MaxLength(50)]
    public string? Email { get; set; }

    [Column("address_id")]
    public short AddressId { get; set; }

    [Column("activebool")]
    public bool ActiveBool { get; set; }

    // legacy/extra integer column present in schema
    [Column("active")]
    public int? Active { get; set; }

    [Column("create_date")]
    public DateTime CreateDate { get; set; }

    [Column("last_update")]
    public DateTime? LastUpdate { get; set; }
}
