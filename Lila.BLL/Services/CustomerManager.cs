using Lila.BLL.DtoModels;
using Lila.BLL.Mappers;
using Lila.BLL.Services.Interfaces;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;

namespace Lila.BLL.Services;

public class CustomerManager : ICustomerManager
{
    private readonly IRepository<Customer> _customerRepository;
    private readonly IRepository<CustomersCity> _customersCityRepository;
    private readonly IRepository<City> _cityRepository;
    
    
}