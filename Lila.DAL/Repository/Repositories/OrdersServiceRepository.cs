using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class OrdersServiceRepository : IRepository<OrdersService>
{
    private readonly Microsoft.EntityFrameworkCore.DbContext _dbContext;

    public OrdersServiceRepository(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<OrdersService> GetAll()
    {
        return _dbContext.Set<OrdersService>()
            .Include(ordersService => ordersService.MyOrder)
            .Include(ordersService => ordersService.Service)
            .Include(ordersService => ordersService.BeginCity)
            .Include(ordersService => ordersService.EndCity)
            .AsNoTracking()
            .ToList();
    }

    public OrdersService GetById(int id)
    {
        return _dbContext.Set<OrdersService>()
            .Include(ordersService => ordersService.MyOrder)
            .Include(ordersService => ordersService.Service)
            .Include(ordersService => ordersService.BeginCity)
            .Include(ordersService => ordersService.EndCity)
            .AsNoTracking()
            .ToList()
            .FirstOrDefault(ordersService => ordersService.Id == id)!;
    }

    public int Create(OrdersService item)
    {
        _dbContext.Set<OrdersService>().Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(OrdersService item)
    {
        _dbContext.Set<OrdersService>().Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(OrdersService item)
    {
        _dbContext.Set<OrdersService>().Remove(item);
        _dbContext.SaveChanges();
    }
}