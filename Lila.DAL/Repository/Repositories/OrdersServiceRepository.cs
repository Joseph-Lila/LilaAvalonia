using Lila.DAL.Repository.DbContext;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class OrdersServiceRepository : IRepository<OrdersService>
{
    private readonly ApplicationContext _dbContext;

    public OrdersServiceRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<OrdersService> GetAll()
    {
        return _dbContext.OrdersServices
            .Include(ordersService => ordersService.MyOrder)
            .Include(ordersService => ordersService.Service)
            .Include(ordersService => ordersService.BeginCity)
            .Include(ordersService => ordersService.EndCity)
            .AsNoTracking()
            .ToList();
    }

    public OrdersService GetById(int id)
    {
        return GetAll()
            .FirstOrDefault(ordersService => ordersService.Id == id)!;
    }

    public int Create(OrdersService item)
    {
        GetAll().Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(OrdersService item)
    {
        _dbContext.OrdersServices.Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(OrdersService item)
    {
        _dbContext.OrdersServices.Remove(item);
        _dbContext.SaveChanges();
    }
}