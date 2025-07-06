using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;

namespace CleanArchitecture.Persistance.Repositories;

public sealed class CarRepository : GenericRepository<Car, AppDbContext>, ICarRepository
{
    public CarRepository(AppDbContext context) : base(context) { }
    
    
}