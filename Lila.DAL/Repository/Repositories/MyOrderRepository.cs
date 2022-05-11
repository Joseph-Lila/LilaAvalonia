using Lila.DAL.Repository.DbContext;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class MyOrderRepository : IRepository<MyOrder>
{
    private readonly ApplicationContext _dbContext;

    public MyOrderRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<MyOrder> GetAll()
    {
        return _dbContext.MyOrders
            .Include(myOrder => myOrder.Customer)
            .Include(myOrder => myOrder.Stage)
            .Include(myOrder => myOrder.Status)
            .Include(myOrder => myOrder.OrdersTransports)
            .AsNoTracking()
            .ToList();
    }

    public MyOrder GetById(int id)
    {
        return GetAll()
            .FirstOrDefault(myOrder => myOrder.Id == id)!;
    }

    public int Create(MyOrder item)
    {
        GetAll().Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(MyOrder item)
    {
        _dbContext.MyOrders.Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(MyOrder item)
    {
        _dbContext.MyOrders.Remove(item);
        _dbContext.SaveChanges();
    }
}