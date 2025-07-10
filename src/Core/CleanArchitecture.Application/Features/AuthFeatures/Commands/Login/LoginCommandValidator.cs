using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;

public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(p => p.UserNameOrEmail).NotEmpty().WithMessage("Kullanıcı adı veya şifre boş olamaz");
        RuleFor(p => p.UserNameOrEmail).NotNull().WithMessage("Kullanıcı adı veya şifre boş olamaz");
        RuleFor(p => p.UserNameOrEmail).MinimumLength(3).WithMessage("Kullanıcı adı veya şifre en az 3 karakter olmalıdır");

        RuleFor(x => x.Password).NotNull().WithMessage("Parola alanı boş olamaz");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Parola alanı boş olamaz");
        RuleFor(x => x.Password).Matches("[a-z]").WithMessage("Parola bir en az bir küçük harf içermelidir.");
        RuleFor(x => x.Password).Matches("[A-Z]").WithMessage("Parola bir en az bir büyük harf içermelidir.");
        RuleFor(x => x.Password).Matches("[0-9]").WithMessage("Parola bir en az bir rakam içermelidir.");
        RuleFor(x => x.Password).Matches("[^a-zA-Z0-9]").WithMessage("Parola bir en az bir özel karakter içermelidir.");
    }
}