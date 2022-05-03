using Lila.BLL.DtoModels.Interfaces;

namespace Lila.BLL.DtoModels;

public class StatusDto : IBaseEntityDto
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
}