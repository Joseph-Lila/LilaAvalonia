using System.ComponentModel.DataAnnotations;
using Lila.BLL.DtoModels;
using Lila.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lila.Web.Pages.Account;

public class AddCustomer : PageModel
{
    private readonly ICustomerManager _customerManager;
    private readonly ICityManager _cityManager;
    private readonly IUserManager _userManager;
    private readonly ICustomersCityManager _customersCityManager;
    [BindProperty]
    public CustomerDto Customer { get; set; }
    [BindProperty]
    public CityDto City { get; set; }
    [BindProperty]
    public UserDto User { get; set; }
    public List<CustomerDto> Customers { get; set; }
    public AddCustomer(ICustomerManager customerManager, ICityManager cityManager, IUserManager userManager)
    {
        _customerManager = customerManager;
        _userManager = userManager;
        _cityManager = cityManager;
    }
    public void OnGet()
    {
        Customers = _customerManager.GetAll();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if(ModelState.IsValid)
        {
            if (_cityManager.CheckExists(City.Title))
            return RedirectToPage("Index");
        }
        return Page();
    }
}