using AutoMapper;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistance.Mappings;

public class RegisterProfile : Profile
{
    public RegisterProfile()
    {
        CreateMap<RegisterCommand, AppUser>();
    }
    
}