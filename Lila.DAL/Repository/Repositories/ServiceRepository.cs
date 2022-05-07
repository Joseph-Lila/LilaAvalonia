using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class ServiceRepository : IRepository<Service>
{
    private readonly Microsoft.EntityFrameworkCore.DbContext _dbContext;

    public ServiceRepository(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Service> GetAll()
    {
        return _dbContext.Set<Service>()
            .Include(service => service.OrdersServices)
            .AsNoTracking()
            .ToList();
    }

    public Service GetById(int id)
    {
        return _dbContext.Set<Service>()
            .Include(service => service.OrdersServices)
            .AsNoTracking()
            .ToList()
            .FirstOrDefault(service => service.Id == id)!;
    }

    public int Create(Service item)
    {
        _dbContext.Set<Service>().Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(Service item)
    {
        _dbContext.Set<Service>().Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(Service item)
    {
        _dbContext.Set<Service>().Remove(item);
        _dbContext.SaveChanges();
    }
}