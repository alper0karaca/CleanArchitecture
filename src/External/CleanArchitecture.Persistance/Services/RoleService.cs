using CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Persistance.Services;

public class RoleService : IRoleService
{
    private readonly RoleManager<AppRole> _roleManager;
    
    public RoleService(RoleManager<AppRole> roleManager)
    {
        _roleManager = roleManager;
    }
    
    public async Task CreateRoleAsync(CreateRoleCommand request)
    {
        AppRole appRole = new()
        {
            Name = request.Name
        };
        IdentityResult result = await _roleManager.CreateAsync(appRole);

        if (!result.Succeeded) 
            throw new Exception("Rol kaydı yapılırken bir hata gerçekleşti");
    }
}