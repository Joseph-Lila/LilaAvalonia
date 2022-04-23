using Lila.BLL.DtoModels.Interfaces;

namespace Lila.BLL.DtoModels;

public class CustomersCityDto : IBaseEntityDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CityId { get; set; }
}