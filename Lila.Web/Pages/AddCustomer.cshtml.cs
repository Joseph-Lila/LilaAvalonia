using Lila.BLL.DtoModels;
using Lila.BLL.Services;
using Lila.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lila.Web.Pages;

public class AddCustomer : PageModel
{
    private readonly SignUpManager _manager;
    private readonly CityManager _cityManager;
    [BindProperty] public SignUpDto item { get; set; }
    [BindProperty] public List<City> Cities { get; set; }
    public List<SelectListItem> CityList { set; get; }

    public AddCustomer(SignUpManager manager, CityManager cityManager)
    {
        _manager = manager;
        _cityManager = cityManager;
        Cities = _cityManager.GetCities();
        CityList = new List<SelectListItem>();
        foreach (var city in Cities)
        {
            CityList.Add(new SelectListItem(city.Title,city.Title));
        }
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