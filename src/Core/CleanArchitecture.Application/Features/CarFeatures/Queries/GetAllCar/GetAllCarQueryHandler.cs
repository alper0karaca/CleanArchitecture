using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;

public class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery, IList<CarDto>>
{
    private readonly ICarService _carService;

    public GetAllCarQueryHandler(ICarService carService)
    {
        _carService = carService;
    }
    
    public async Task<IList<CarDto>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        IList<CarDto> carList = await _carService.GetAllAsync(request, cancellationToken);
        return carList;
    }
}