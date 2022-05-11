using Lila.DAL.Repository.DbContext;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class UsersRoleRepository : IRepository<UsersRole>
{
    private readonly ApplicationContext _dbContext;

    public UsersRoleRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<UsersRole> GetAll()
    {
        return _dbContext.Set<UsersRole>()
            .Include(usersRole => usersRole.User)
            .Include(usersRole => usersRole.Role)
            .ToList();
    }

    public UsersRole GetById(int id)
    {
        return GetAll()
            .FirstOrDefault(usersRole => usersRole.Id == id)!;
    }

    public int Create(UsersRole item)
    {
        _dbContext.UsersRoles.Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(UsersRole item)
    {
        _dbContext.UsersRoles.Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(UsersRole item)
    {
        _dbContext.UsersRoles.Remove(item);
        _dbContext.SaveChanges();
    }
}