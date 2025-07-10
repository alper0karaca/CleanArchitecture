using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Abtractions;

public interface IJwtProvider
{
    Task<LoginCommandResponse> CreateTokenAsync(AppUser user);
}