using Lila.BLL.Services;
using Lila.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lila.Web.Pages.Order;

[Authorize(Policy = "ForCustomer")]
public class OrdersHistory : PageModel
{
    private readonly OrderManager _orderManager;

    public OrdersHistory(OrderManager orderManager)
    {
        _orderManager = orderManager;
    }

    [BindProperty] public List<MyOrder> MyOrders { get; set; } = new();

    public void OnGet()
    {
        MyOrders = _orderManager.GetMyOrders(User.Identity!.Name!);
    }

    public IActionResult OnPost(int orderId)
    {
        MyOrders = _orderManager.GetMyOrders(User.Identity!.Name!);
        _orderManager.MarkAsPaid(MyOrders.Find(x => x.Id == orderId)!);
        return Page();
    }
}