using Lila.Domain.Interfaces;

namespace Lila.DAL.Repository.Interfaces;

public interface IRepository<T> where T : class?, IBaseEntity?
{
    public IQueryable<T> GetAll();
    public Task<T> GetById(int id);
    public Task<int> Create(T item);
    public Task Update(T item);
    public Task Delete(int id);
}