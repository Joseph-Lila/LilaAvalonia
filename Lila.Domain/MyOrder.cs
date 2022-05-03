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
    public int? CustomerId { get; set; } // FK
    public Customer? Customer { get; set; } // nav. property
    public int? OperatorId { get; set; }
    public int? CourierId { get; set; }
    public int? StageId { get; set; } // FK
    public Stage? Stage { get; set; } // nav. property
    public int? StatusId { get; set; } // FK
    public Status? Status { get; set; } // nav. property
}