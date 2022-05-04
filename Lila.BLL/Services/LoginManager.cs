using System.Security.Claims;
using Lila.BLL.DtoModels;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;

namespace Lila.BLL.Services;

public class LoginManager
{
    private readonly IRepository<User> _userRep;
    private readonly IRepository<UsersRole> _usersRoleRep;
    private readonly IRepository<Role> _roleRep;

    public LoginManager(IRepository<User> userRep, IRepository<UsersRole> usersRoleRep, IRepository<Role> roleRep)
    {
        _userRep = userRep;
        _usersRoleRep = usersRoleRep;
        _roleRep = roleRep;
    }

    private LoginDto MakeDto(string login, string password)
    {
        LoginDto loginDto = new LoginDto();
        User? user = _userRep.GetAll().Find(x => x.Login == login && x.Password == password);
        if (user == null)
            loginDto.Roles = null;
        else
        {
            List<int> rolesIds = new List<int>();
            List<string> roles = new List<string>();
            loginDto.Login = user.Login;
            loginDto.Password = user.Password;
            loginDto.Email = user.Email;
            loginDto.PhoneNumber = user.PhoneNumber;
            foreach (var item in _usersRoleRep.GetAll())
            {
                if (item.UserId == user.Id)
                    rolesIds.Add(item.RoleId);
            }

            foreach (var role in _roleRep.GetAll())
            {
                if (rolesIds.Contains(role.Id))
                    roles.Add(role.Title);
            }

            loginDto.Roles = roles;
        }

        return loginDto;
    }
    public List<Claim>? GetHisRights(string login, string password)
    {
        LoginDto he = MakeDto(login, password);
        if (he.Roles == null)
            return null;
        List<Claim> claims = new List<Claim>();
        
        // add vital claim (it is unique due to Login + Password uniqueness)
        claims.Add(new Claim(ClaimTypes.Name, he.Login));
        // add common claim
        claims.Add(new Claim(ClaimTypes.Email, he.Email));
        
        // add particular claims affecting pages access
        foreach (var role in he.Roles)
        {
            claims.Add(new Claim(role, "true"));
        }

        return claims;
    }
}