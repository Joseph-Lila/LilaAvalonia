using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class UsersRoleRepository : IRepository<UsersRole>
{
    private readonly Microsoft.EntityFrameworkCore.DbContext _dbContext;

    public UsersRoleRepository(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<UsersRole> GetAll()
    {
        return _dbContext.Set<UsersRole>()
            .Include(usersRole => usersRole.User)
            .Include(usersRole => usersRole.Role)
            .AsNoTracking()
            .ToList();
    }

    public UsersRole GetById(int id)
    {
        return _dbContext.Set<UsersRole>()
            .Include(usersRole => usersRole.User)
            .Include(usersRole => usersRole.Role)
            .AsNoTracking()
            .ToList()
            .FirstOrDefault(usersRole => usersRole.Id == id)!;
    }

    public int Create(UsersRole item)
    {
        _dbContext.Set<UsersRole>().Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(UsersRole item)
    {
        _dbContext.Set<UsersRole>().Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(UsersRole item)
    {
        _dbContext.Set<UsersRole>().Remove(item);
        _dbContext.SaveChanges();
    }
}