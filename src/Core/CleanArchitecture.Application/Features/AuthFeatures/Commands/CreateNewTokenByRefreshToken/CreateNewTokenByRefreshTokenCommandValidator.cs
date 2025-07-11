using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;

public sealed class CreateNewTokenByRefreshTokenCommandValidator : AbstractValidator<CreateNewTokenByRefreshTokenCommand>
{
    public CreateNewTokenByRefreshTokenCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User bilgisi boş olamaz");
        RuleFor(x => x.UserId).NotNull().WithMessage("User bilgisi boş olamaz");
        
        RuleFor(x => x.RefreshToken).NotNull().WithMessage("Refresh Token bilgisi boş olamaz");
        RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("Refresh Token bilgisi boş olamaz");
        
    }
    
}