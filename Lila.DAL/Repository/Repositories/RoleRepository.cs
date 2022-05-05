using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class RoleRepository : IRepository<Role>
{
    private readonly Microsoft.EntityFrameworkCore.DbContext _dbContext;

    public RoleRepository(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Role> GetAll()
    {
        return _dbContext.Set<Role>()
            .Include(role => role.UsersRoles)
            .AsNoTracking()
            .ToList();
    }

    public Role GetById(int id)
    {
        return _dbContext.Set<Role>()
            .Include(role => role.UsersRoles)
            .AsNoTracking()
            .ToList()
            .FirstOrDefault(role => role.Id == id)!;
    }

    public int Create(Role item)
    {
        _dbContext.Set<Role>().Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(Role item)
    {
        _dbContext.Set<Role>().Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(Role item)
    {
        _dbContext.Set<Role>().Remove(item);
        _dbContext.SaveChanges();
    }
}