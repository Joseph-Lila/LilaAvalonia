using Lila.BLL.DtoModels.Interfaces;

namespace Lila.BLL.DtoModels;

public class CityDto : IBaseEntityDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
}