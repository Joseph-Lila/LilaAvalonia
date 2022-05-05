using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lila.Domain.Interfaces;

namespace Lila.Domain;

[Table("MyOrders")]
public class MyOrder : IBaseEntity
{
    [Key]
    public int Id { get; set; }
    public DateTime? Commissions { get; set; }
    public DateTime? Executions { get; set; }
    public int? OperatorId { get; set; }
    public int? CourierId { get; set; }
    // ---
    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }
    // ---
    public int? StageId { get; set; }
    public Stage? Stage { get; set; }
    // ---
    public int? StatusId { get; set; }
    public Status? Status { get; set; }
    // ---
    public List<OrdersTransport> OrdersTransports { get; set; } = new();
}