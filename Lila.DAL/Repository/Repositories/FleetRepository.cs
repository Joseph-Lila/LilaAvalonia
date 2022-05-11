using Lila.DAL.Repository.DbContext;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class FleetRepository : IRepository<Fleet>
{
    private readonly ApplicationContext _dbContext;

    public FleetRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Fleet> GetAll()
    {
        return _dbContext.Set<Fleet>()
            .Include(fleet => fleet.City)
            .Include(fleet => fleet.Transports)
            .AsNoTracking()
            .ToList();
    }

    public Fleet GetById(int id)
    {
        return _dbContext.Set<Fleet>()
            .Include(fleet => fleet.City)
            .Include(fleet => fleet.Transports)
            .AsNoTracking()
            .ToList()
            .FirstOrDefault(fleet => fleet.Id == id)!;
    }

    public int Create(Fleet item)
    {
        _dbContext.Set<Fleet>().Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(Fleet item)
    {
        _dbContext.Set<Fleet>().Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(Fleet item)
    {
        _dbContext.Set<Fleet>().Remove(item);
        _dbContext.SaveChanges();
    }
}