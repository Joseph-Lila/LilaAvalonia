using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lila.Domain.Interfaces;

namespace Lila.Domain;

[Table("Stages")]
public class Stage : IBaseEntity
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
}