using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lila.Domain.Interfaces;

namespace Lila.Domain;

[Table("Services")]
public class Service : IBaseEntity
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public double CostWeight { get; set; }
    public double CostRadius { get; set; }
}