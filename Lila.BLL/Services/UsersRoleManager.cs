using Lila.BLL.DtoModels;
using Lila.BLL.Services.Interfaces;

namespace Lila.BLL.Services;

public class UsersRoleManager : IUsersRoleManager
{
    public List<UsersRoleDto?> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<UsersRoleDto?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> Create(UsersRoleDto? item)
    {
        throw new NotImplementedException();
    }

    public Task Update(UsersRoleDto? item)
    {
        throw new NotImplementedException();
    }
}