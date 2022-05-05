using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lila.Domain.Interfaces;

namespace Lila.Domain;

[Table("Customers")]
public class Customer : IBaseEntity
{
    [Key]
    public int Id { get; set; }
    public string Country { get; set; } = "";
    public string Street { get; set; } = "";
    public int HomeNumber { get; set; }
    public int FlatNumber { get; set; }
    public string LastName { get; set; } = "";
    public string Name { get; set; } = "";
    public string MiddleName { get; set; } = "";
    // ---
    public int UserId { get; set; }
    public User? User { get; set; }
    // ---
    public List<CustomersCity> CustomersCities { get; set; } = new();
    public List<MyOrder> MyOrders { get; set; } = new();
}