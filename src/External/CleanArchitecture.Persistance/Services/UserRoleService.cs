using CleanArchitecture.Application.Features.UserRoleFeatures.Commands;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistance.Services;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public UserRoleService(IUserRoleRepository userRoleRepository, IUnitOfWork unitOfWork)
    {
        _userRoleRepository = userRoleRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        AppUserRole appUserRole = new AppUserRole()
        {
            UserId = request.UserId,
            RoleId = request.RoleId,
        };
        
        await _userRoleRepository.AddAsync(appUserRole);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

