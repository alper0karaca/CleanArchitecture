using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services;

public interface ICarService
{
    Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken);
    Task<IList<CarDto>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken);
    Task<PaginationResponse<CarDto>> GetAllPaginatedAsync(PaginationRequest request);

}