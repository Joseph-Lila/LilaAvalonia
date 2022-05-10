using Lila.BLL.Services;
using Lila.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lila.Web.Pages.Order;

[Authorize(Policy = "ForCustomer")]
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
        CityList = new List<SelectListItem>();
        foreach (var city in Cities)
        {
            CityList.Add(new SelectListItem(city.Title,city.Title));
        }
    }
    [BindProperty] public string BeginCityTitle { get; set; }
    [BindProperty] public string EndCityTitle { get; set; }
    public List<SelectListItem> CityList { set; get; }
    [BindProperty] public OrdersService OrdersService { get; set; } = new();
    [BindProperty] public List<City> Cities { get; set; }
    
    public void OnGet(int? id)
    {
        if (id != null)
        {
            OrdersService.Service = _serviceManager.GetById((int) id) ?? new Service();
            OrdersService.ServiceId = OrdersService.Service.Id;
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {

        if (!HttpContext.Session.Keys.Contains(CartKey))
        {
            HttpContext.Session.SetString(CartKey, _orderManager.CartJsonString());
        }
        _orderManager.UpdateCartByJsonString(HttpContext.Session.GetString(CartKey)!);
        OrdersService.BeginCityId = _cityManager.GetByTitle(BeginCityTitle)!.Id;
        OrdersService.EndCityId = _cityManager.GetByTitle(EndCityTitle)!.Id;
        OrdersService.ServiceId = Int32.Parse(RouteData.Values["id"]!.ToString()!);
        _orderManager.AddOrdersServiceLocally(OrdersService);
        HttpContext.Session.SetString(CartKey, _orderManager.CartJsonString());
        return RedirectToPage("ServicesList");
    }
}