using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lila.Web.Pages;

[Authorize(Policy = "ForOperator")]
public class OperatorsPage : PageModel
{
    public void OnGet()
    {
        
    }
}