using CleanArchitecture.Application.Features.UserRoleFeatures.Commands;

namespace CleanArchitecture.Application.Services;

public interface IUserRoleService
{
    Task CreateAsync(CreateUserRoleCommand request, 
        CancellationToken cancellationToken);
}