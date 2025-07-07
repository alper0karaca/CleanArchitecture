using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;

public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Email).NotNull().WithMessage("Mail bilgisi boş olamaz");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Mail bilgisi boş olamaz");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir mail adresi girin");
     
        RuleFor(x => x.UserName).NotNull().WithMessage("Kullanıcı adı boş olamaz");
        RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
        RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır");
        
        RuleFor(x => x.Password).NotNull().WithMessage("Parola alanı boş olamaz");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Parola alanı boş olamaz");
        RuleFor(x => x.Password).Matches("[a-z]").WithMessage("Parola bir en az bir küçük harf içermelidir.");
        RuleFor(x => x.Password).Matches("[A-Z]").WithMessage("Parola bir en az bir büyük harf içermelidir.");
        RuleFor(x => x.Password).Matches("[0-9]").WithMessage("Parola bir en az bir rakam içermelidir.");
        RuleFor(x => x.Password).Matches("[^a-zA-Z0-9]").WithMessage("Parola bir en az bir rakam içermelidir.");
    }
}