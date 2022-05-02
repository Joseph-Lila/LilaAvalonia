using System.Collections;
using Lila.BLL.DtoModels;
using Lila.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lila.Web.Pages;

public class IndexModel : PageModel, IEnumerable
{
    private readonly ICityManager _manager;
    public List<CityDto> Cities { get; set; }
    [BindProperty]
    public string Name { get; set; } = null!;

    [BindProperty]
    public int? Age { get; set; }
    public bool IsCorrect { get; set; } = false;

    public IndexModel(ICityManager manager)
    {
        _manager = manager;
    }
    public void OnGet()
    {
        Cities = _manager.GetAll();
    }

    public void OnPost()
    {
        if (Age == null || Age < 1 || Age > 110 || string.IsNullOrEmpty(Name))
        {
            IsCorrect = false;
            return;
        }

        IsCorrect = true;
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}