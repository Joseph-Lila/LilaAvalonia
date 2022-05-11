using Lila.DAL.Repository.DbContext;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class StageRepository : IRepository<Stage>
{
    private readonly ApplicationContext _dbContext;

    public StageRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Stage> GetAll()
    {
        return _dbContext.Set<Stage>()
            .Include(stage => stage.MyOrders)
            .AsNoTracking()
            .ToList();
    }

    public Stage GetById(int id)
    {
        return _dbContext.Set<Stage>()
            .Include(stage => stage.MyOrders)
            .AsNoTracking()
            .ToList()
            .FirstOrDefault(stage => stage.Id == id)!;
    }

    public int Create(Stage item)
    {
        _dbContext.Set<Stage>().Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(Stage item)
    {
        _dbContext.Set<Stage>().Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(Stage item)
    {
        _dbContext.Set<Stage>().Remove(item);
        _dbContext.SaveChanges();
    }
}