using Lila.BLL.DtoModels;
using Lila.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lila.Web.Pages;

public class AddCustomer : PageModel
{
    private readonly SignUpManager _manager;
    [BindProperty]
    public SignUpDto item { get; set; }

    public AddCustomer(SignUpManager manager)
    {
        _manager = manager;
    }
    
    public void OnGet()
    {
        
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if(ModelState.IsValid)
        {
            if (_manager.RegisterCustomer(item))
            {
                return RedirectToPage("/Account/Login");
            }
        }
        return Page();
    }
}