using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Repositories;

public class UserRoleRepository : GenericRepository<AppUserRole, AppDbContext>, IUserRoleRepository
{
    public UserRoleRepository(AppDbContext context) : base(context) { }
    
    public async Task<List<string>> GetRolesByUserIdAsync(string userId)
    {
        var result = await _context.UserRoles
            .Where(ur => ur.UserId == userId)
            .Include(ur => ur.AppRole) // AppUserRole → Role ilişkisi
            .Select(ur => ur.AppRole.Name)
            .ToListAsync();

        return result;
    }
}