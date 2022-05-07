using Lila.BLL.DtoModels;
using Lila.BLL.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lila.Web.Pages.Order;

public class DoOrder : PageModel
{
    private readonly OrderManager _manager;
    private const string CartKey = "cartStore";
    public List<ShopCartItemDto> ShopCartItems { get; set; } = new();

    public DoOrder(OrderManager manager)
    {
        _manager = manager;
    }

    public void OnGet()
    {
        if (!HttpContext.Session.Keys.Contains(CartKey))
        {
            HttpContext.Session.SetString(CartKey, _manager.CartJsonString());
        }
        _manager.UpdateCartByJsonString(HttpContext.Session.GetString(CartKey)!);
        ShopCartItems = _manager.Cart.ShopCartItems;
    }
    
}