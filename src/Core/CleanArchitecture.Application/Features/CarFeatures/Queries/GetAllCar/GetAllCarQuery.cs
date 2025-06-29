using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;

// CQRS mutlaaka IRequest ister
public sealed record GetAllCarQuery() : IRequest<IList<CarDto>>;