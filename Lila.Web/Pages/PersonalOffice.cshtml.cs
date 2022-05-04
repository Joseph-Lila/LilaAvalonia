using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lila.Web.Pages;

[Authorize]
public class PersonalOffice : PageModel
{
    public void OnGet()
    {
        
    }
}