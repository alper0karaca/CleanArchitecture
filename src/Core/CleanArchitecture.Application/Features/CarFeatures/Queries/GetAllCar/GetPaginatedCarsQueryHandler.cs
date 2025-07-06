using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;

public class GetPaginatedCarsQueryHandler : IRequestHandler<GetPaginatedCarsQuery, PaginationResponse<CarDto>>
{
    private readonly ICarService _carService;
    
    public GetPaginatedCarsQueryHandler(ICarService carService)
    {
        _carService = carService;
    }
    
    public async Task<PaginationResponse<CarDto>> Handle(GetPaginatedCarsQuery request, CancellationToken cancellationToken)
    {
        return await _carService.GetAllPaginatedAsync(request);
    }
}