using System.Collections;
using Lila.BLL.DtoModels;
using Lila.BLL.Mappers;
using Lila.BLL.Services.Interfaces;
using Lila.DAL.Repository.DbContext;
using Lila.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lila.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ICityManager _cityManager;
    public List<CityDto> Cities { get; set; }

    public IndexModel(ICityManager cityManager)
    {
        _cityManager = cityManager;
    }
    
    public void OnGet()
    {
        Cities = _cityManager.GetAll();
    }
}