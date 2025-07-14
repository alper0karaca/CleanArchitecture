using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitecture.Domain.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Entities;

public class AppUserRole : IdentityUserRole<string>
{
    public AppUser AppUser { get; set; }
    public AppRole AppRole { get; set; }
}