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
        return _dbContext.Set<CustomersCity>()
            .Include(customersCity => customersCity.Customer)
            .Include(customersCity => customersCity.City)
            .AsNoTracking()
            .ToList();
    }

    public CustomersCity GetById(int id)
    {
        return _dbContext.Set<CustomersCity>()
            .Include(customersCity => customersCity.Customer)
            .Include(customersCity => customersCity.City)
            .AsNoTracking()
            .ToList()
            .FirstOrDefault(customersCity => customersCity.Id == id)!;
    }

    public int Create(CustomersCity item)
    {
        _dbContext.Set<CustomersCity>().Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(CustomersCity item)
    {
        _dbContext.Set<CustomersCity>().Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(CustomersCity item)
    {
        _dbContext.Set<CustomersCity>().Remove(item);
        _dbContext.SaveChanges();
    }
}