using Application.Services.Repositories;
using Core.Persistense.Repositories;
using Domain.Entities;
using Persistence.Contextx;

namespace Persistence.Repositories;

public class ColorRepository : EFRepositoryBase<Color, BaseDbContext>, IColorRepository
{
    public ColorRepository(BaseDbContext context) : base(context)
    {
    }
}