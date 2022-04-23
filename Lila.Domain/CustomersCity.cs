using Lila.Domain.Interfaces;

namespace Lila.Domain;

public class CustomersCity : IBaseEntity
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CityId { get; set; }
}