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

    private bool CheckExistUser(string login, string password)
    {
        return _userRep.GetAll().Find(x => x.Login == login && x.Password == password) != null;
    }
    
    public bool RegisterCustomer(SignUpDto item)
    {
        if (!CheckExistUser(item.Login, item.Password))
        {
            // check if city exists
            int? cityId = _cityRep.GetAll().Find(x => x.Title == item.CityTitle)?.Id;
            if (cityId == null)
                return false;
            // add user in db
            _userRep.Create(new User 
                {Email = item.Email, Login = item.Login, Password = item.Password, PhoneNumber = item.PhoneNumber,});
            // get new user id
            int userId = _userRep.GetAll().Find(user => user.Email == item.Email && user.Login == item.Login 
                && user.Password == item.Password && user.PhoneNumber == item.PhoneNumber)!.Id;
            // get roleId for "Customer"
            int roleId = _roleRep.GetAll().Find(role => role.Title == "Customer")!.Id;
            // now we are ready to add users role in the db
            _usersRoleRep.Create(new UsersRole { RoleId = roleId, UserId = userId});
            // add customer to db
            _customerRep.Create(new Customer
            {Country = item.Country, FlatNumber = item.FlatNumber, HomeNumber = item.HomeNumber, 
                LastName = item.LastName, MiddleName = item.MiddleName, Name = item.Name, Street = item.Street,
                UserId = userId,});
            // get new customer id
            int customerId = _customerRep.GetAll().Find(x =>
                x.Country == item.Country && x.FlatNumber == item.FlatNumber && x.HomeNumber == item.HomeNumber
                && x.LastName == item.LastName && x.MiddleName == item.MiddleName && x.Name == item.Name
                && x.Street == item.Street && x.UserId == userId)!.Id;
            _customersCityRep.Create(new CustomersCity {CityId = (int) cityId, CustomerId = customerId});
            return true;
        }

        return false;
    }
}