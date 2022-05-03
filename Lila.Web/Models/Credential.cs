using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lila.Web.Models;

public class Credential
{
    [Required]
    [DisplayName("Users Name")]
    public string UsersName { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}