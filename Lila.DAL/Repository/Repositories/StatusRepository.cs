using Lila.DAL.Repository.DbContext;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class StatusRepository : IRepository<Status>
{
    private readonly ApplicationContext _dbContext;

    public StatusRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Status> GetAll()
    {
        return _dbContext.Set<Status>()
            .Include(status => status.Employees)
            .Include(status => status.MyOrders)
            .AsNoTracking()
            .ToList();
    }

    public Status GetById(int id)
    {
        return _dbContext.Set<Status>()
            .Include(status => status.Employees)
            .Include(status => status.MyOrders)
            .AsNoTracking()
            .ToList()
            .FirstOrDefault(status => status.Id == id)!;
    }

    public int Create(Status item)
    {
        _dbContext.Set<Status>().Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(Status item)
    {
        _dbContext.Set<Status>().Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(Status item)
    {
        _dbContext.Set<Status>().Remove(item);
        _dbContext.SaveChanges();
    }
}