using Lila.DAL.Repository.DbContext;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class EmployeeRepository : IRepository<Employee>
{
    private readonly ApplicationContext _dbContext;

    public EmployeeRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Employee> GetAll()
    {
        return _dbContext.Set<Employee>()
            .Include(employee => employee.User)
            .Include(employee => employee.Status)
            .AsNoTracking()
            .ToList();
    }

    public Employee GetById(int id)
    {
        return _dbContext.Set<Employee>()
            .Include(employee => employee.User)
            .Include(employee => employee.Status)
            .AsNoTracking()
            .ToList()
            .FirstOrDefault(employee => employee.Id == id)!;
    }

    public int Create(Employee item)
    {
        _dbContext.Set<Employee>().Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(Employee item)
    {
        _dbContext.Set<Employee>().Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(Employee item)
    {
        _dbContext.Set<Employee>().Remove(item);
        _dbContext.SaveChanges();
    }
}