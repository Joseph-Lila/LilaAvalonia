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

    public List<City> GetCities()
    {
        return _cityRep.GetAll();
    }

    public City GetById(int id)
    {
        return _cityRep.GetById(id);
    }

    public City? GetByTitle(string title)
    {
        return _cityRep.GetAll().Find(x => x.Title == title) ?? null;
    }
}