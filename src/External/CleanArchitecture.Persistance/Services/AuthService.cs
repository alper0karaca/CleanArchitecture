using AutoMapper;
using CleanArchitecture.Application.Abtractions;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AppUser = CleanArchitecture.Domain.Entities.AppUser;

namespace CleanArchitecture.Persistance.Services;

public sealed class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;
    private readonly IJwtProvider _jwtProvider;

    public AuthService(UserManager<AppUser> userManager, IMapper mapper, IMailService mailService, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _mapper = mapper;
        _mailService = mailService;
        _jwtProvider = jwtProvider;
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

    public async Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await _userManager.Users.Where(
            x => x.UserName == request.UserNameOrEmail 
                    || x.Email == request.UserNameOrEmail)
            .FirstOrDefaultAsync(cancellationToken);

        if (user == null) throw new Exception("Kullanıcı bulunamadı");

        var result = await _userManager.CheckPasswordAsync(user, request.Password);
        
        if (result)
        {
            LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
            return response;
        }

        throw new Exception("Eposta veya şifre hatalıdır.");
    }

    public async Task<LoginCommandResponse> CreateTokenByRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        AppUser user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null) throw new Exception("Kullanıcı bulunamadı");

        if (user.RefreshToken != request.RefreshToken)
            throw new Exception("Refresh Token geçerli değil!");
        
        if (user.RefreshTokenExpires < DateTime.Now)
            throw new Exception("Refresh Token süresi dolmuştur!");

        LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
        return response;

    }
}










