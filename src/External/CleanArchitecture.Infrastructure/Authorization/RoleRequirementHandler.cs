using System.Security.Claims;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
namespace CleanArchitecture.Infrastructure.Authorization;

public class RoleRequirementHandler : AuthorizationHandler<RoleRequirement>
{
    private readonly IUserRoleRepository _userRoleRepository;
    
    public RoleRequirementHandler(IUserRoleRepository userRoleRepository)
    {
        _userRoleRepository = userRoleRepository;
    }
    
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
    {
        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (string.IsNullOrWhiteSpace(userId)) 
            return;

        var roles = await _userRoleRepository.GetRolesByUserIdAsync(userId);
        
        if (roles.Contains(requirement.RequiredRole))
        {
            context.Succeed(requirement); // Yetkili
        }

    }
}