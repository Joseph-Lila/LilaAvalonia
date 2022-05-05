using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class CustomerRepository : IRepository<Customer>
{
    private readonly Microsoft.EntityFrameworkCore.DbContext _dbContext;

    public CustomerRepository(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Customer> GetAll()
    {
        return _dbContext.Set<Customer>()
            .Include(city => city.User)
            .Include(city => city.CustomersCities)
            .Include(city => city.MyOrders)
            .AsNoTracking()
            .ToList();
    }

    public Customer GetById(int id)
    {
        return _dbContext.Set<Customer>()
            .Include(city => city.User)
            .Include(city => city.CustomersCities)
            .Include(city => city.MyOrders)
            .AsNoTracking()
            .ToList()
            .FirstOrDefault(customer => customer.Id == id)!;
    }

    public int Create(Customer item)
    {
        _dbContext.Set<Customer>().Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(Customer item)
    {
        _dbContext.Set<Customer>().Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(Customer item)
    {
        _dbContext.Set<Customer>().Remove(item);
        _dbContext.SaveChanges();
    }
}