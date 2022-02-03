
using Application.Features.Fuel.Dtos;
using Application.Features.Fuel.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuel.Commands;

public class UpdateFuelCommand : IRequest<FuelDto>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdatefuelHandler : IRequestHandler<UpdateFuelCommand, FuelDto>
    {
        private IFuelRepository _fuelRepository;
        private IMapper _mapper;
        private FuelBusinessRules _fuelBusinessRules;

        public UpdatefuelHandler(FuelBusinessRules fuelBusinessRules, IFuelRepository fuelRepository, IMapper mapper)
        {
            _fuelBusinessRules = fuelBusinessRules;
            _fuelRepository = fuelRepository;
            _mapper = mapper;
        }


        public async Task<FuelDto> Handle(UpdateFuelCommand request, CancellationToken cancellationToken)
        {
            var fuel = await _fuelRepository.GetAsync(x => x.Id == request.Id);

            if (fuel == null)
                throw new BusinessException("fuel cannot found");

            await _fuelBusinessRules.FuelNameCanNotBeDuplicatedWhenInsertedAndUpdated(request.Name);

            _mapper.Map(request, fuel);

            await _fuelRepository.UpdateAync(fuel);

            var dto = _mapper.Map<FuelDto>(fuel);

            return dto;
        }
    }

}