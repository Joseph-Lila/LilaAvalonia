using Lila.BLL.Services;
using Lila.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lila.Web.Pages;

[Authorize(Policy = "ForOperator")]
public class OperatorsPage : PageModel
{
    private readonly OperatorsManager _manager;
    

    public OperatorsPage(OperatorsManager manager)
    {
        _manager = manager;
    }

    [BindProperty] public List<User> FreeCouriers { get; set; }
    [BindProperty] public List<MyOrder> UnpaidOrders { get; set; }
    public void OnGet()
    {
        FreeCouriers = _manager.GetFreeCouriers();
        UnpaidOrders = _manager.GetUnpaidOrders();
    }
}