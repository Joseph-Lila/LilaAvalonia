using Lila.Domain.Interfaces;

namespace Lila.Domain;

public class Transport : IBaseEntity
{
    public int Id { get; set; }
    public int KindId { get; set; }
    public int FleetId { get; set; }
}