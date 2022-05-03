using Lila.BLL.DtoModels.Interfaces;

namespace Lila.BLL.DtoModels;

public class MyOrderDto : IBaseEntityDto
{
    public int Id { get; set; }
    public DateTime? Commissions { get; set; }
    public DateTime? Executions { get; set; }
    public int? CustomerId { get; set; } // FK
    public CustomerDto? Customer { get; set; } // nav. property
    public int? OperatorId { get; set; }
    public int? CourierId { get; set; }
    public int? StageId { get; set; } // FK
    public StageDto? Stage { get; set; } // nav. property
    public int? StatusId { get; set; } // FK
    public StatusDto? Status { get; set; } // nav. property
}