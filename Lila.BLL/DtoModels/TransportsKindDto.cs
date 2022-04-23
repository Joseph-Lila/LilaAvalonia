using Lila.BLL.DtoModels.Interfaces;

namespace Lila.BLL.DtoModels;

public class TransportsKindDto : IBaseEntityDto
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public string? Title { get; set; }
    public double LiftingCapacity { get; set; }
    public double Volume { get; set; }
}