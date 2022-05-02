using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lila.Web.Pages;

public class LogInModel : PageModel
{
    record class Person(string Email, string Password);
    
    public void OnGet()
    {
        
    }

    public IActionResult OnPost(string? returnUrl, HttpContext context)
    {
        var people = new List<Person>
        {
            new Person("qwerty", "1234"),
            new Person("bob@gmail.com", "55555")
        };
        var form = context.Request.Form;
        // если email и/или пароль не установлены, посылаем статусный код ошибки 400
        if (!form.ContainsKey("email") || !form.ContainsKey("password"))
            return Redirect("/LogIn");
 
        string email = form["email"];
        string password = form["password"];
     
        // находим пользователя 
        Person? person = people.FirstOrDefault(p => p.Email == email && p.Password == password);
        // если пользователь не найден, отправляем статусный код 401
        if (person is null) return Unauthorized();
 
        var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.Email) };
        // создаем объект ClaimsIdentity
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
        // установка аутентификационных куки
        context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        return Redirect(returnUrl??"/");
    }
}