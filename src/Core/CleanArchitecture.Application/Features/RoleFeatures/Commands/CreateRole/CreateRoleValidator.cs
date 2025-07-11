using FluentValidation;

namespace CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;

public sealed class CreateRoleValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleValidator()
    {
        RuleFor(p => p.Name).NotNull().WithMessage("Rol adı boş olamaz");
        RuleFor(p => p.Name).NotEmpty().WithMessage("Rol adı boş olamaz");
        
    }
}