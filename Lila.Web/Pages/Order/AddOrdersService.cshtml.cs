using Lila.BLL.Services;
using Lila.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lila.Web.Pages.Order;

public class AddOrdersService : PageModel
{
    private readonly OrderManager _orderManager;
    private readonly ServiceManager _serviceManager;
    private readonly CityManager _cityManager;
    private const string CartKey = "cartStore";

    public AddOrdersService(OrderManager orderManager, ServiceManager serviceManager, CityManager cityManager)
    {
        _orderManager = orderManager;
        _serviceManager = serviceManager;
        _cityManager = cityManager;
        Cities = _cityManager.GetCities();
    }
    
    [BindProperty]
    public OrdersService OrdersService { get; set; } = new();
    [BindProperty]
    public List<City> Cities { get; set; }

    public void OnGet(int? id)
    {
        if (id != null)
        {
            OrdersService.Service = _serviceManager.GetById((int) id) ?? new Service();
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if(ModelState.IsValid)
        {
            if (!HttpContext.Session.Keys.Contains(CartKey))
            {
                HttpContext.Session.SetString(CartKey, _orderManager.CartJsonString());
            }
            _orderManager.UpdateCartByJsonString(HttpContext.Session.GetString(CartKey)!);
            _orderManager.AddOrdersService(OrdersService);
            HttpContext.Session.SetString(CartKey, _orderManager.CartJsonString());
            return RedirectToPage("ServicesList");
        }
        return Page();
    }
}