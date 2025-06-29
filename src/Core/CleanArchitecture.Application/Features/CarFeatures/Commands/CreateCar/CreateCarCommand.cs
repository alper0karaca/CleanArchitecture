using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;

/*
 * record : bu sınıfın sabit, değiştirilemeyecek verileri iletmekle yükümlü olduğunu belirtiyoruz.
 * ayrıca iş kuralları içermemesini, içerik olarak karşılaştırılabilmesini, değişmeden tekrar kullanılabilmesini sağlar 
 */

public sealed record CreateCarCommand(
    string Name,
    string Model,
    int Power) : IRequest<MessageResponse>;
