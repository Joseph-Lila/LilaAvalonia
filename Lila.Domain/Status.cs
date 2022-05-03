using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lila.Domain.Interfaces;

namespace Lila.Domain;

[Table("Statuses")]
public class Status : IBaseEntity
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
}