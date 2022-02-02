using Application.Services.Repositories;
using Core.Persistense.Repositories;
using Domain.Entities;
using Persistence.Contextx;

namespace Persistence.Repositories;

public class BrandRepository : EFRepositoryBase<Brand, BaseDbContext>, IBrandRepository
{
    public BrandRepository(BaseDbContext context) : base(context)
    {
    }
}