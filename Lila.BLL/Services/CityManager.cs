using Lila.DAL.Repository.Interfaces;
using Lila.Domain;

namespace Lila.BLL.Services;

public class CityManager
{
    private readonly IRepository<City> _cityRep;

    public CityManager(IRepository<City> cityRep)
    {
        _cityRep = cityRep;
    }

    public List<City> GetAll()
    {
        return _cityRep.GetAll();
    }
}