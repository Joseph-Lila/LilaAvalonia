using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class TransportRepository : IRepository<Transport>
{
    private readonly Microsoft.EntityFrameworkCore.DbContext _dbContext;

    public TransportRepository(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Transport> GetAll()
    {
        return _dbContext.Set<Transport>()
            .Include(transport => transport.TransportsKind)
            .Include(transport => transport.Fleet)
            .Include(transport => transport.OrdersTransports)
            .AsNoTracking()
            .ToList();
    }

    public Transport GetById(int id)
    {
        return _dbContext.Set<Transport>()
            .Include(transport => transport.TransportsKind)
            .Include(transport => transport.Fleet)
            .Include(transport => transport.OrdersTransports)
            .AsNoTracking()
            .ToList()
            .FirstOrDefault(transport => transport.Id == id)!;
    }

    public int Create(Transport item)
    {
        _dbContext.Set<Transport>().Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(Transport item)
    {
        _dbContext.Set<Transport>().Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(Transport item)
    {
        _dbContext.Set<Transport>().Remove(item);
        _dbContext.SaveChanges();
    }
}