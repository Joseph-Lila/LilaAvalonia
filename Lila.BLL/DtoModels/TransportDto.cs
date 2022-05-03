using Lila.BLL.DtoModels.Interfaces;

namespace Lila.BLL.DtoModels;

public class TransportDto : IBaseEntityDto
{
    public int Id { get; set; }
    public int KindId { get; set; } // FK
    public TransportsKindDto? Kind { get; set; } // nav. property
    public int FleetId { get; set; } // FK
    public FleetDto? Fleet { get; set; } // nav. property
}