using Application.Services.Repositories;
using Core.Application.Response;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace Application.Features.Fuel.Commands;

public class DeleteFuelCommand : IRequest<NoContent>
{
    public int Id { get; set; }

    public class DeleteBrandHandler : IRequestHandler<DeleteFuelCommand, NoContent>
    {
        private IFuelRepository _fuelRepository;

        public DeleteBrandHandler(IFuelRepository fuelRepository)
        {
            _fuelRepository = fuelRepository;
        }

        public async Task<NoContent> Handle(DeleteFuelCommand request, CancellationToken cancellationToken)
        {
            var brand = await _fuelRepository.GetAsync(x => x.Id == request.Id);

            if (brand == null) throw new BusinessException("Fuel cannot found");

            await _fuelRepository.DeleteAsync(brand);

            return new NoContent();
        }
    }
}