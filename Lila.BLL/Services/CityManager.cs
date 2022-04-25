using Lila.BLL.DtoModels;
using Lila.BLL.Mappers;
using Lila.BLL.Services.Interfaces;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;


namespace Lila.BLL.Services;

public class CityManager : ICityManager
{
    private readonly IRepository<City> _repository;

    public CityManager(IRepository<City> repository)
    {
        _repository = repository;
    }
    
    public List<CityDto?> GetAll()
    {
        var items = _repository.GetAll().ToList();
        return CityMapper.CastToDto(items);
    }

    public async Task<CityDto?> GetById(int id)
    {
        var item = await _repository.GetById(id);
        return await CityMapper.CastToDto(item);
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(id);
    }

    public async Task<int> Create(CityDto? item)
    {
        return await _repository.Create(await CityMapper.CastFromDto(item) ?? throw new InvalidOperationException());
    }

    public async Task Update(CityDto? item)
    {
        await _repository.Update(await CityMapper.CastFromDto(item) ?? throw new InvalidOperationException());
    }
}