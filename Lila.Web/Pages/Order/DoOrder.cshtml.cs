using Lila.BLL.DtoModels;
using Lila.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lila.Web.Pages.Order;

public class DoOrder : PageModel
{
    private readonly OrderManager _orderManager;
    private const string CartKey = "cartStore";
    public List<ShopCartItemDto> ShopCartItems { get; set; } = new();

    public DoOrder(OrderManager orderManager)
    {
        _orderManager = orderManager;
    }

    public void OnGet()
    {
        if (!HttpContext.Session.Keys.Contains(CartKey))
        {
            HttpContext.Session.SetString(CartKey, _orderManager.CartJsonString());
        }
        _orderManager.UpdateCartByJsonString(HttpContext.Session.GetString(CartKey)!);
        ShopCartItems = _orderManager.Cart.ShopCartItems;
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if(ModelState.IsValid)
        {
            _orderManager.UpdateCartByJsonString(HttpContext.Session.GetString(CartKey)!);
            ShopCartItems = _orderManager.Cart.ShopCartItems;
            _orderManager.AddFullOrder(User.Identity.Name, ShopCartItems);
            HttpContext.Session.Clear();
            ShopCartItems = new List<ShopCartItemDto>();
            return RedirectToPage("/PersonalOffice");
        }
        return Page();
    }
}