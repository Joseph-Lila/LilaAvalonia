using Lila.BLL.DtoModels.Interfaces;

namespace Lila.BLL.Services.Interfaces;

public interface IService<T> where T : class, IBaseEntityDto
{
    public List<T?> GetAll();
    public Task<T?> GetById(int id);
    public Task Delete(int id);
    public Task<int> Create(T? item);
    public Task Update(T? item);
}