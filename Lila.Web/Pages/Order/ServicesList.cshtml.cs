using Lila.BLL.Services;
using Lila.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lila.Web.Pages.Order;

[Authorize(Policy = "ForCustomer")]
public class ServicesList : PageModel
{
    private readonly ServiceManager _manager;

    public ServicesList(ServiceManager manager)
    {
        _manager = manager;
    }
    [BindProperty]
    public List<Service?> Services { get; set; } = new();
    
    public void OnGet()
    {
        Services = _manager.Services;
    }
}