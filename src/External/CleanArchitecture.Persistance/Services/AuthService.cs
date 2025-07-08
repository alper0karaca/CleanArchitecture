using AutoMapper;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using AppUser = CleanArchitecture.Domain.Entities.AppUser;

namespace CleanArchitecture.Persistance.Services;

public sealed class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;

    public AuthService(UserManager<AppUser> userManager, IMapper mapper, IMailService mailService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _mailService = mailService;
    }
    
    public async Task RegisterAsync(RegisterCommand request)
    {
        AppUser user = _mapper.Map<AppUser>(request);
        IdentityResult result = await _userManager.CreateAsync(user,request.Password);
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }

        await _mailService.SendMailAsync(request.Email, 
            "Clean Arch Sistemine başarıyla kayıt oluşturuldu",
            $"Hoş geldin {request.UserName}, kayıt işlemin başarılı oldu.");
    }
}