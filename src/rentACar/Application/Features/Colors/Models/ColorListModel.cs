using Application.Features.Colors.Dtos;
using Core.Persistense.Paging;

namespace Application.Features.Colors.Models;

public class ColorListModel : BasePageableModel
{
    public IList<ColorListDto> Items { get; set; }
}