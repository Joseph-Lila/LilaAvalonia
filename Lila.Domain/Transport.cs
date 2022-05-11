using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lila.Domain.Interfaces;

namespace Lila.Domain;

[Table("Transports")]
public class Transport : IBaseEntity
{
    [Key]
    public int Id { get; set; }
    // ---
    public int TransportsKindId { get; set; }
    public TransportsKind? TransportsKind { get; set; }
    // ---
    public int FleetId { get; set; }
    public Fleet? Fleet { get; set; }
    // ---
    public List<OrdersTransport> OrdersTransports { get; set; } = new();
}