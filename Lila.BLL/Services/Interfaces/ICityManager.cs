using Lila.BLL.DtoModels;

namespace Lila.BLL.Services.Interfaces;

public interface ICityManager
{
    public List<CityDto> GetAll();

    public CityDto GetById(int id);
    
    public int Create(CityDto city);
    
    public void Update(CityDto city);

    public void Delete(CityDto city);
}