using Lila.DAL.Repository.DbContext;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class RoleRepository : IRepository<Role>
{
    private readonly ApplicationContext _dbContext;

    public RoleRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Role> GetAll()
    {
        return _dbContext.Roles
            .Include(role => role.UsersRoles)
            .AsNoTracking()
            .ToList();
    }

    public Role GetById(int id)
    {
        return GetAll()
            .FirstOrDefault(role => role.Id == id)!;
    }

    public int Create(Role item)
    {
        GetAll().Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(Role item)
    {
        _dbContext.Roles.Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(Role item)
    {
        _dbContext.Roles.Remove(item);
        _dbContext.SaveChanges();
    }
}