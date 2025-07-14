using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces;

public interface IUserRoleRepository : IGenericRepository<AppUserRole>
{
    Task<List<string>> GetRolesByUserIdAsync(string userId);
}