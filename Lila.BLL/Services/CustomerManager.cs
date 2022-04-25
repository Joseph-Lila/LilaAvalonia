using Lila.BLL.DtoModels;
using Lila.BLL.Services.Interfaces;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;

namespace Lila.BLL.Services;

public class CustomerManager
{
    private readonly IRepository<Customer> _repository;

    public CustomerManager(IRepository<Customer> repository)
    {
        _repository = repository;
    }
    
}