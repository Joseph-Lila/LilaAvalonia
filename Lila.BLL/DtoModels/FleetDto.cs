using Lila.BLL.DtoModels.Interfaces;

namespace Lila.BLL.DtoModels;

public class FleetDto : IBaseEntityDto
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Address { get; set; } = "";
    public double Square { get; set; }
    public int StarsQuantity { get; set; }
    public int CityId { get; set; } // FK
    public CityDto? City { get; set; } // nav. property
}