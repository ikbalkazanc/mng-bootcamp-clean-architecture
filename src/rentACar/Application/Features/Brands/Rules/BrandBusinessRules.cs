using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Brands.Rules;

public class BrandBusinessRules
{
    IBrandRepository _brandRepository;

    public BrandBusinessRules(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    //Gerkhin 
    public async Task BrandNameCanNotBeDuplicatedWhenInsertedAndUpdated(string name)
    {
        var result = await _brandRepository.GetListAsync(b => b.Name == name);
        if (result.Items.Any())
        {
            throw new BusinessException("Brand name exists");
        }
    }

    //public async Task<Brand> IsExist(int id)
    //{
    //    var result = await _brandRepository.GetAsync(x => x.Id == id);

    //    if (result == null)
    //    {
    //       throw new BusinessException("Brand cannot found");
    //    }

    //    return result;
    //}
}