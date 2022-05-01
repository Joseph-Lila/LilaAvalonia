using Lila.BLL.DtoModels;
using Lila.BLL.Mappers;
using Lila.BLL.Services.Interfaces;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;


namespace Lila.BLL.Services;

internal class CityManager : ICityManager
{
    private readonly IRepository<City> _repository;

    public CityManager(IRepository<City> repository)
    {
        _repository = repository;
    }

    public List<CityDto> GetAll()
    {
        return CityMapper.CastToDto(_repository.GetAll());
    }

    public CityDto GetById(int id)
    {
        return CityMapper.CastToDto(_repository.GetById(id));
    }

    public int Create(CityDto city)
    {
        _repository.Create(CityMapper.CastFromDto(city));
        return city.Id;
    }

    public void Update(CityDto city)
    {
        _repository.Update(CityMapper.CastFromDto(city));
    }

    public void Delete(CityDto city)
    {
        _repository.Delete(CityMapper.CastFromDto(city));
    }
}