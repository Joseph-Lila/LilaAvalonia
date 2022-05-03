using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lila.Domain.Interfaces;

namespace Lila.Domain;

[Table("CustomersCities")]
public class CustomersCity : IBaseEntity
{
    [Key]
    public int Id { get; set; } 
    public int CustomerId { get; set; } // FK
    public Customer? Customer { get; set; } // nav. property
    public int CityId { get; set; } // FK
    public City? City { get; set; } // nav. property
}