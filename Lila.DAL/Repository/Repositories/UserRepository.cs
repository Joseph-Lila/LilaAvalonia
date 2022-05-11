using Lila.DAL.Repository.DbContext;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class UserRepository : IRepository<User>
{
    private readonly ApplicationContext _dbContext;

    public UserRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<User> GetAll()
    {
        return _dbContext.Set<User>()
            .Include(user => user.Customers)
            .Include(user => user.UsersRoles)
            .Include(user => user.Employees)
            .ToList();
    }

    public User GetById(int id)
    {
        return GetAll()
            .FirstOrDefault(user => user.Id == id)!;
    }

    public int Create(User item)
    {
        _dbContext.Users.Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(User item)
    {
        _dbContext.Users.Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(User item)
    {
        _dbContext.Users.Remove(item);
        _dbContext.SaveChanges();
    }
}