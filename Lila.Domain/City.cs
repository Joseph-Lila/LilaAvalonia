using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lila.Domain.Interfaces;

namespace Lila.Domain;

[Table("Cities")]
public class City : IBaseEntity
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }
    [Column("Title")]
    public string Title { get; set; } = "";
}
