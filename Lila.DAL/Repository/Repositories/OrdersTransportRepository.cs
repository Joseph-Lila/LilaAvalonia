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
        return _dbContext.OrdersTransports
            .Include(ordersTransport => ordersTransport.Transport)
            .Include(ordersTransport => ordersTransport.MyOrder)
            .AsNoTracking()
            .ToList();
    }

    public OrdersTransport GetById(int id)
    {
        return GetAll()
            .FirstOrDefault(ordersTransport => ordersTransport.Id == id)!;
    }

    public int Create(OrdersTransport item)
    {
        GetAll().Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(OrdersTransport item)
    {
        _dbContext.OrdersTransports.Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(OrdersTransport item)
    {
        _dbContext.OrdersTransports.Remove(item);
        _dbContext.SaveChanges();
    }
}