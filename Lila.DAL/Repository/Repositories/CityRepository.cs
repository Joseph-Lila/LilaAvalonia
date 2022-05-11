using Lila.DAL.Repository.DbContext;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class CityRepository : IRepository<City>
{
    private readonly ApplicationContext _dbContext;

    public CityRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<City> GetAll()
    {
        return _dbContext.Cities
            .Include(city => city.Fleets)
            .Include(city => city.CustomersCities)
            .Include(city => city.OrdersServiceBeginCities)
            .Include(city => city.OrdersServiceEndCities)
            .AsNoTracking()
            .ToList();
    }

    public City GetById(int id)
    {
        return GetAll()
            .FirstOrDefault(city => city.Id == id)!;
    }

    public int Create(City item)
    {
        GetAll().Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(City item)
    {
        _dbContext.Cities.Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(City item)
    {
        _dbContext.Cities.Remove(item);
        _dbContext.SaveChanges();
    }
}