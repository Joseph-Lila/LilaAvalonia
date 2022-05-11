using Lila.DAL.Repository.DbContext;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class CustomerRepository : IRepository<Customer>
{
    private readonly ApplicationContext _dbContext;

    public CustomerRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Customer> GetAll()
    {
        return _dbContext.Customers
            .Include(city => city.User)
            .Include(city => city.CustomersCities)
            .Include(city => city.MyOrders)
            .ToList();
    }

    public Customer GetById(int id)
    {
        return GetAll()
            .FirstOrDefault(customer => customer.Id == id)!;
    }

    public int Create(Customer item)
    {
        _dbContext.Customers.Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(Customer item)
    {
        _dbContext.Customers.Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(Customer item)
    {
        _dbContext.Customers.Remove(item);
        _dbContext.SaveChanges();
    }
}