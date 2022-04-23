using Lila.BLL.DtoModels.Interfaces;

namespace Lila.BLL.DtoModels;

public class TransportDto : IBaseEntityDto
{
    public int Id { get; set; }
    public int KindId { get; set; }
    public int FleetId { get; set; }
}