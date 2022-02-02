using Application.Services.Repositories;
using Core.Persistense.Repositories;
using Domain.Entities;
using Persistence.Contextx;

namespace Persistence.Repositories;

public class ModelRepository : EFRepositoryBase<Model, BaseDbContext>, IModelRepository
{
    public ModelRepository(BaseDbContext context) : base(context)
    {
    }
}