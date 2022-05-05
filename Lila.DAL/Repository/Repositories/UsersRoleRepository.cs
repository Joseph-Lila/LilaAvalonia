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
        throw new NotImplementedException();
    }

    public int Create(UsersRole item)
    {
        throw new NotImplementedException();
    }

    public void Update(UsersRole item)
    {
        throw new NotImplementedException();
    }

    public void Delete(UsersRole item)
    {
        throw new NotImplementedException();
    }
}