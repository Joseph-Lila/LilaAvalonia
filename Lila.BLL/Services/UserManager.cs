using Lila.BLL.DtoModels;
using Lila.BLL.Services.Interfaces;

namespace Lila.BLL.Services;

public class UserManager : IUserManager
{
    public List<UserDto?> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<UserDto?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> Create(UserDto? item)
    {
        throw new NotImplementedException();
    }

    public Task Update(UserDto? item)
    {
        throw new NotImplementedException();
    }
}