using Lila.DAL.Repository.DbContext;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class CustomersCityRepository : IRepository<CustomersCity>
{
    private readonly ApplicationContext _dbContext;

    public CustomersCityRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<CustomersCity> GetAll()
    {
        return _dbContext.CustomersCities
            .Include(customersCity => customersCity.Customer)
            .Include(customersCity => customersCity.City)
            .ToList();
    }

    public CustomersCity GetById(int id)
    {
        return GetAll()
            .FirstOrDefault(customersCity => customersCity.Id == id)!;
    }

    public int Create(CustomersCity item)
    {
        _dbContext.CustomersCities.Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(CustomersCity item)
    {
        _dbContext.CustomersCities.Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(CustomersCity item)
    {
        _dbContext.CustomersCities.Remove(item);
        _dbContext.SaveChanges();
    }
}