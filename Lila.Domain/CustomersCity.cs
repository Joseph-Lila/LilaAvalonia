using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lila.Domain.Interfaces;

namespace Lila.Domain;

[Table("CustomersCities")]
public class CustomersCity : IBaseEntity
{
    [Key]
    public int Id { get; set; } 
    // ---
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    // ---
    public int CityId { get; set; }
    public City? City { get; set; }
}