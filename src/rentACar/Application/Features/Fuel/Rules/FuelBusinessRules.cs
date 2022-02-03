using Application.Services.Repositories;

namespace Application.Features.Fuel.Rules;

public class FuelBusinessRules
{
    private IFuelRepository _fuelRepository;

    public FuelBusinessRules(IFuelRepository fuelRepository)
    {
        _fuelRepository = fuelRepository;
    }


}