using Lila.BLL.DtoModels.Interfaces;

namespace Lila.BLL.DtoModels;

public class OrdersServiceDto : IBaseEntityDto
{
    public int Id { get; set; }
    public int ServiceId { get; set; } // FK
    public ServiceDto? Service { get; set; } // nav. property
    public int MyOrderId { get; set; } // FK
    public MyOrderDto? MyOrder { get; set; } // nav. property
    public double QuantityWeight { get; set; }
    public double QuantityRadius { get; set; }
    public string DestinationsAddress { get; set; } = "";
    public string DeparturesAddress { get; set; } = "";
    public double TotalCost { get; set; }
    public int BeginCityId { get; set; } // FK
    public CityDto? BeginCity { get; set; } // nav. property
    public int EndCityId { get; set; } // FK
    public CityDto? EndCity { get; set; } // nav. property
}