using Lila.DAL.Repository.DbContext;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class OrdersTransportRepository : IRepository<OrdersTransport>
{
    private readonly ApplicationContext _dbContext;

    public OrdersTransportRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<OrdersTransport> GetAll()
    {
        return _dbContext.Set<OrdersTransport>()
            .Include(ordersTransport => ordersTransport.Transport)
            .Include(ordersTransport => ordersTransport.MyOrder)
            .AsNoTracking()
            .ToList();
    }

    public OrdersTransport GetById(int id)
    {
        return _dbContext.Set<OrdersTransport>()
            .Include(ordersTransport => ordersTransport.Transport)
            .Include(ordersTransport => ordersTransport.MyOrder)
            .AsNoTracking()
            .ToList()
            .FirstOrDefault(ordersTransport => ordersTransport.Id == id)!;
    }

    public int Create(OrdersTransport item)
    {
        _dbContext.Set<OrdersTransport>().Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(OrdersTransport item)
    {
        _dbContext.Set<OrdersTransport>().Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(OrdersTransport item)
    {
        _dbContext.Set<OrdersTransport>().Remove(item);
        _dbContext.SaveChanges();
    }
}