using AutoMapper;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistance.Mappings;

public sealed class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<CreateCarCommand, Car>().ReverseMap();
        CreateMap<Car, CarDto>();
    }
}