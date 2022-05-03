using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lila.Domain.Interfaces;

namespace Lila.Domain;

[Table("TransportsKinds")]
public class TransportsKind : IBaseEntity
{
    [Key]
    public int Id { get; set; }
    public string Description { get; set; } = "";
    public string Title { get; set; } = "";
    public double LiftingCapacity { get; set; }
    public double Volume { get; set; }
}