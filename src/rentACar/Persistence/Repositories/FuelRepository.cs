using Application.Services.Repositories;
using Core.Persistense.Repositories;
using Domain.Entities;
using Persistence.Contextx;

namespace Persistence.Repositories;

public class FuelRepository : EFRepositoryBase<Fuel,BaseDbContext> ,IFuelRepository
{
    public FuelRepository(BaseDbContext context) : base(context)
    {
    }
}