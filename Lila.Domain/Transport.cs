using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lila.Domain.Interfaces;

namespace Lila.Domain;

[Table("Transports")]
public class Transport : IBaseEntity
{
    [Key]
    public int Id { get; set; }
    public int KindId { get; set; } // FK
    public TransportsKind? Kind { get; set; } // nav. property
    public int FleetId { get; set; } // FK
    public Fleet? Fleet { get; set; } // nav. property
}