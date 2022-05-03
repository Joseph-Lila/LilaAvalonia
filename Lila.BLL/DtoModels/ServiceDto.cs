using Lila.BLL.DtoModels.Interfaces;

namespace Lila.BLL.DtoModels;

public class ServiceDto : IBaseEntityDto
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public double CostWeight { get; set; }
    public double CostRadius { get; set; }
}