using System.Security.Principal;
using Lila.BLL.DtoModels;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;

namespace Lila.BLL.Services;

public class SignUpManager
{
    private readonly IRepository<User> _userRep;
    private readonly IRepository<UsersRole> _usersRoleRep;
    private readonly IRepository<Role> _roleRep;
    private readonly IRepository<Customer> _customerRep;
    private readonly IRepository<CustomersCity> _customersCityRep;
    private readonly IRepository<City> _cityRep;

    public SignUpManager(IRepository<User> userRep, IRepository<UsersRole> usersRoleRep, IRepository<Role> roleRep, IRepository<Customer> customerRep, IRepository<CustomersCity> customersCityRep, IRepository<City> cityRep)
    {
        _userRep = userRep;
        _usersRoleRep = usersRoleRep;
        _roleRep = roleRep;
        _customerRep = customerRep;
        _customersCityRep = customersCityRep;
        _cityRep = cityRep;
    }

    private bool CheckExistUser(string login)
    {
        return _userRep.GetAll().Find(x => x.Login == login) != null;
    }
    
    public bool RegisterCustomer(SignUpDto item)
    {
        if (!CheckExistUser(item.Login))
        {
            // check if city exists
            int? cityId = _cityRep.GetAll().Find(x => x.Title == item.CityTitle)?.Id;
            int userId = _userRep.Create(new User 
                {Email = item.Email, Login = item.Login, Password = item.Password, PhoneNumber = item.PhoneNumber,});
            int roleId = _roleRep.GetAll().Find(role => role.Title == "Customer")!.Id;
            _usersRoleRep.Create(new UsersRole { RoleId = roleId, UserId = userId});
            int customerId = _customerRep.Create(new Customer
            {Country = item.Country, FlatNumber = item.FlatNumber, HomeNumber = item.HomeNumber, 
                LastName = item.LastName, MiddleName = item.MiddleName, Name = item.Name, Street = item.Street,
                UserId = userId,});
            Console.WriteLine($"!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!----{customerId} ------ {userId}");
            _customersCityRep.Create(new CustomersCity {CityId = (int) cityId, CustomerId = customerId});
            return true;
        }
        return false;
    }
}