using Lila.DAL.Repository.Interfaces;
using Lila.Domain;

namespace Lila.BLL.Services;

public class OperatorsManager
{
    private readonly IRepository<MyOrder> _myOrderRep;
    private readonly IRepository<Employee> _employeeRep;
    private readonly IRepository<User> _userRep;
    private readonly IRepository<UsersRole> _usersRoleRep;
    private readonly IRepository<Role> _roleRep;
    private readonly IRepository<Status> _statusRep;

    public OperatorsManager(IRepository<MyOrder> myOrderRep, IRepository<Employee> employeeRep, IRepository<User> userRep, IRepository<UsersRole> usersRoleRep, IRepository<Role> roleRep, IRepository<Status> statusRep)
    {
        _myOrderRep = myOrderRep;
        _employeeRep = employeeRep;
        _userRep = userRep;
        _usersRoleRep = usersRoleRep;
        _roleRep = roleRep;
        _statusRep = statusRep;
    }

    public List<MyOrder> GetUnpaidOrders()
    {
        return (from x in _myOrderRep.GetAll()
            where x.Status.Title == "Оплачен" 
                  && x.Stage.Title == "На рассмотрении" 
                  && x.CourierId == null 
                  && x.OperatorId == null
            select x).ToList();
    }
    public List<User> GetFreeCouriers()
    {
        int roleId = _roleRep.GetAll().Find(x => x.Title == "Courier")!.Id;
        var freeUsers = (from e in _employeeRep.GetAll()
            where e.Status.Title == "Свободен"
            select e.UserId).ToList();
        var couriers = (from x in _usersRoleRep.GetAll()
            where x.RoleId == roleId
            select x.UserId).ToList();
        var usersIds = freeUsers.Intersect(couriers).ToList();
        return (from z in usersIds
            select _userRep.GetById(z)).ToList();
    }
}