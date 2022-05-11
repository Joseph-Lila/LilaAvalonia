using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lila.Web.Pages;

[Authorize(Policy = "ForCourier")]
public class CouriersPage : PageModel
{
    public void OnGet()
    {
        
    }
}