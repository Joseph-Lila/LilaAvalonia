using Lila.Domain;

namespace Lila.DAL.Repository.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    public IQueryable<T> GetAll(); //получение коллекции объектов
    public Task<T?> GetById(int id); // получение одного объекта по id
    public Task<int> Create(T item); // создание объекта
    
    public Task Update(T item); // обновление объекта
    public Task Delete(int id); // удаление объекта по id
}