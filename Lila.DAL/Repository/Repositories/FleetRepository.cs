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
        return _dbContext.Fleets
            .Include(fleet => fleet.City)
            .Include(fleet => fleet.Transports)
            .AsNoTracking()
            .ToList();
    }

    public Fleet GetById(int id)
    {
        return GetAll()
            .FirstOrDefault(fleet => fleet.Id == id)!;
    }

    public int Create(Fleet item)
    {
        GetAll().Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(Fleet item)
    {
        _dbContext.Fleets.Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(Fleet item)
    {
        _dbContext.Fleets.Remove(item);
        _dbContext.SaveChanges();
    }
}