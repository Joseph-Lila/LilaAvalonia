namespace Lila.Domain;

public class MyOrder : BaseEntity
{
    public DateTime Commissions { get; set; }
    public DateTime Executions { get; set; }
    public int CustomerId { get; set; }
    public int OperatorId { get; set; }
    public int CourierId { get; set; }
    public int StageId { get; set; }
    public int StatusId { get; set; }
}