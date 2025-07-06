using AutoMapper;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Services;

public sealed class CarService : ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CarService(ICarRepository carRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _carRepository = carRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken)
    {
        Car car = _mapper.Map<Car>(request);
        await _carRepository.AddAsync(car);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<CarDto>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        var cars = await _carRepository.ListAllAsync();
        return _mapper.Map<IList<CarDto>>(cars);
    }

    public async Task<PaginationResponse<CarDto>> GetAllPaginatedAsync(PaginationRequest request)
    {
        var (items, totalCount) = await _carRepository.GetPaginatedAsync(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize
        );

        var dtoList = _mapper.Map<IReadOnlyList<CarDto>>(items);

        return new PaginationResponse<CarDto>(
            dtoList,
            totalCount,
            request.PageNumber,
            request.PageSize
        );
    }
}