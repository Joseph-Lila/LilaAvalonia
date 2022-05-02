using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lila.Web.Pages;

public class AccessDeniedModel : PageModel
{
    public void OnGet()
    {
        Response.StatusCode = 403;
        Response.WriteAsync("Access Denied");
    }
}