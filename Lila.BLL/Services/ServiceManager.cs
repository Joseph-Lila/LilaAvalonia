using Lila.DAL.Repository.Interfaces;
using Lila.Domain;

namespace Lila.BLL.Services;

public class ServiceManager
{
    private readonly IRepository<Service> _serviceRep;

    public ServiceManager(IRepository<Service> serviceRep)
    {
        _serviceRep = serviceRep;
    }

    public Service? GetById(int id)
    {
        return Services.Find(x => x.Id == id);
    }
    public List<Service> Services => _serviceRep.GetAll();
}