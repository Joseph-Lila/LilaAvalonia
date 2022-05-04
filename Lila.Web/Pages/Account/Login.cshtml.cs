using System.Security.Claims;
using Lila.BLL.DtoModels;
using Lila.BLL.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lila.Web.Pages.Account;

public class Login : PageModel
{
    [BindProperty]
    public string LoginValue { get; set; }
    [BindProperty]
    public string PasswordValue { get; set; }

    private readonly LoginManager _loginManager;

    public Login(LoginManager loginManager)
    {
        _loginManager = loginManager;
    }
    
    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        
        var claims = _loginManager.GetHisRights(LoginValue, PasswordValue);
        
        if (claims == null)
            return Page();
       
        var identity = new ClaimsIdentity(claims, "MyCookieAuth");
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

        return RedirectToPage("/PersonalOffice");
    }
}