using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class CityRepository : IRepository<City>
{
    private readonly Microsoft.EntityFrameworkCore.DbContext _dbContext;

    public CityRepository(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<City> GetAll()
    {
        return _dbContext.Set<City>()
            .Include(city => city.Fleets)
            .Include(city => city.CustomersCities)
            .Include(city => city.OrdersServiceBeginCities)
            .Include(city => city.OrdersServiceEndCities)
            .AsNoTracking()
            .ToList();
    }

    public City GetById(int id)
    {
        return _dbContext.Set<City>()
            .Include(city => city.Fleets)
            .Include(city => city.CustomersCities)
            .Include(city => city.OrdersServiceBeginCities)
            .Include(city => city.OrdersServiceEndCities)
            .AsNoTracking()
            .ToList()
            .FirstOrDefault(city => city.Id == id)!;
    }

    public int Create(City item)
    {
        _dbContext.Set<City>().Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(City item)
    {
        _dbContext.Set<City>().Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(City item)
    {
        _dbContext.Set<City>().Remove(item);
        _dbContext.SaveChanges();
    }
}