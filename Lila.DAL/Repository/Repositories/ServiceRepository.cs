using Lila.DAL.Repository.DbContext;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class ServiceRepository : IRepository<Service>
{
    private readonly ApplicationContext _dbContext;

    public ServiceRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Service> GetAll()
    {
        return _dbContext.Services
            .Include(service => service.OrdersServices)
            .AsNoTracking()
            .ToList();
    }

    public Service GetById(int id)
    {
        return GetAll()
            .FirstOrDefault(service => service.Id == id)!;
    }

    public int Create(Service item)
    {
        GetAll().Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(Service item)
    {
        _dbContext.Services.Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(Service item)
    {
        _dbContext.Services.Remove(item);
        _dbContext.SaveChanges();
    }
}