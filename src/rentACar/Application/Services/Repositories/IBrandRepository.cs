using System.Xml.Serialization;
using Core.Persistense.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IBrandRepository : IAsyncRepository<Brand>
{
    
}