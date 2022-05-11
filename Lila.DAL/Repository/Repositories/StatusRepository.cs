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
            .ToList();
    }

    public Status GetById(int id)
    {
        return GetAll()
            .FirstOrDefault(status => status.Id == id)!;
    }

    public int Create(Status item)
    {
        _dbContext.Statuses.Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(Status item)
    {
        _dbContext.Statuses.Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(Status item)
    {
        _dbContext.Statuses.Remove(item);
        _dbContext.SaveChanges();
    }
}