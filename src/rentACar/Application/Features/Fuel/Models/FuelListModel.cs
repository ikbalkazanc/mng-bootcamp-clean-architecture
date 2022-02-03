using Application.Features.Fuel.Dtos;
using Core.Persistense.Paging;
using MediatR;

namespace Application.Features.Fuel.Models;

public class FuelListModel : BasePageableModel
{
    public IList<FuelListItem> Items { get; set; }
}