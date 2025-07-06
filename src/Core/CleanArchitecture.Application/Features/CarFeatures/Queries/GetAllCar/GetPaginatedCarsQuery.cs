using CleanArchitecture.Application.Common;
using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;

public sealed class GetPaginatedCarsQuery : PaginationRequest, IRequest<PaginationResponse<CarDto>>
{
    // filtre veya arama gibi parametreler eklenecekse buraya dahil et
}