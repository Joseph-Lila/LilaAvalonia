using Lila.BLL.Services;
using Lila.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lila.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ServiceManager _manager;

    public IndexModel(ServiceManager manager)
    {
        _manager = manager;
        Services = _manager.Services;
    }

    [BindProperty]
    public List<Service> Services { get; set; }
    
    public void OnGet()
    {
        
    }
}