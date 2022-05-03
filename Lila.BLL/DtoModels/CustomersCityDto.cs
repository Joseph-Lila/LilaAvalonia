using Lila.BLL.DtoModels.Interfaces;

namespace Lila.BLL.DtoModels;

public class CustomersCityDto : IBaseEntityDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; } // FK
    public CustomerDto? Customer { get; set; } // nav. property
    public int CityId { get; set; } // FK
    public CityDto? City { get; set; } // nav. property
}