using System.Collections;
using Lila.BLL.DtoModels;
using Lila.BLL.Mappers;
using Lila.BLL.Services.Interfaces;
using Lila.DAL.Repository.DbContext;
using Lila.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lila.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ApplicationContext _context;
    public List<UsersRole> UsersRoles { get; set; }

    public IndexModel(ApplicationContext context)
    {
        _context = context;
    }
    public void OnGet()
    {
        UsersRoles = _context.UsersRoles.ToList();
    }

    public void OnPost()
    {
        
    }
}