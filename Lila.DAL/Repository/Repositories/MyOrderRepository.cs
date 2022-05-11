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
        return _dbContext.Set<MyOrder>()
            .Include(myOrder => myOrder.Customer)
            .Include(myOrder => myOrder.Stage)
            .Include(myOrder => myOrder.Status)
            .Include(myOrder => myOrder.OrdersTransports)
            .AsNoTracking()
            .ToList();
    }

    public MyOrder GetById(int id)
    {
        return _dbContext.Set<MyOrder>()
            .Include(myOrder => myOrder.Customer)
            .Include(myOrder => myOrder.Stage)
            .Include(myOrder => myOrder.Status)
            .Include(myOrder => myOrder.OrdersTransports)
            .AsNoTracking()
            .ToList()
            .FirstOrDefault(myOrder => myOrder.Id == id)!;
    }

    public int Create(MyOrder item)
    {
        _dbContext.Set<MyOrder>().Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(MyOrder item)
    {
        _dbContext.MyOrders.Attach(item);
        _dbContext.Entry(item).State = EntityState.Modified;
        _dbContext.Set<MyOrder>().Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(MyOrder item)
    {
        _dbContext.Set<MyOrder>().Remove(item);
        _dbContext.SaveChanges();
    }
}