using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Entities;

public class AppRole : IdentityRole<string>
{
    public AppRole()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    public ICollection<AppUserRole>? UserRoles { get; set; }
}