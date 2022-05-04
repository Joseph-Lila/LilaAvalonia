using System.Collections;
using Lila.BLL.DtoModels;
using Lila.BLL.Services.Interfaces;
using Lila.DAL.Repository.DbContext;
using Lila.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lila.Web.Pages;

public class IndexModel : PageModel
{
    public void OnGet()
    {
    }
}