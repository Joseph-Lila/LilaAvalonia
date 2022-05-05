using Lila.BLL.Services;
using Lila.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lila.Web.Pages.Order;

public class DoOrder : PageModel
{
    private readonly OrderManager _manager;
    public List<OrdersService>? OrdersServices { get; set; }

    public DoOrder(OrderManager manager)
    {
        _manager = manager;
    }

    public void OnGet()
    {
        OrdersServices = _manager.MainEntity.Services;
    }
    
    // public IActionResult OnPostDeleteAsync(string serviceTitle, double totalCost, 
    //     string destinationsAddress, string departuresAddress)
    // {
    //     _manager.RemoveService(serviceTitle, totalCost, destinationsAddress, departuresAddress);
    //
    //     return RedirectToPage();
    // }
}