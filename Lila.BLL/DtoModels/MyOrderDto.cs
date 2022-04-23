using Lila.BLL.DtoModels.Interfaces;

namespace Lila.BLL.DtoModels;

public class MyOrderDto : IBaseEntityDto
{
    public int Id { get; set; }
    public DateTime Commissions { get; set; }
    public DateTime Executions { get; set; }
    public int CustomerId { get; set; }
    public int OperatorId { get; set; }
    public int CourierId { get; set; }
    public int StageId { get; set; }
    public int StatusId { get; set; }
}