using Lila.Domain.Interfaces;

namespace Lila.DAL.Repository.Interfaces;

public interface IRepository<T> 
    where T : class, IBaseEntity
{
    public List<T> GetAll();
    public T GetById(int id);
    public int Create(T item);
    public void Update(T item);
    public void Delete(T item);
}