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
            .ToList();
    }

    public Stage GetById(int id)
    {
        return GetAll()
            .FirstOrDefault(stage => stage.Id == id)!;
    }

    public int Create(Stage item)
    {
        _dbContext.Stages.Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(Stage item)
    {
        _dbContext.Stages.Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(Stage item)
    {
        _dbContext.Stages.Remove(item);
        _dbContext.SaveChanges();
    }
}