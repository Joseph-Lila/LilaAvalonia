using Lila.BLL.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lila.Web.Pages;

public class IndexModel : PageModel
{

    public IndexModel(CityManager manager)
    {
    }

    
    public void OnGet()
    {
    }
}