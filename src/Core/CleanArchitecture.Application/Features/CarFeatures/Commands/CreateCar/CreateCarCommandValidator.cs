using FluentValidation;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
 
public sealed class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("Araç adı boş olamaz!");
        RuleFor(p => p.Name).NotNull().WithMessage("Araç adı boş olamaz!");
        RuleFor(p => p.Name).MinimumLength(3).WithMessage("Araç adı en az 3 karakter olmalıdır!");
        
        RuleFor(p => p.Model).NotNull().WithMessage("Araç modeli boş olamaz!");
        RuleFor(p => p.Model).NotEmpty().WithMessage("Araç modeli boş olamaz!");
        RuleFor(p => p.Name).MinimumLength(3).WithMessage("Araç modeli en az 3 karakter olmalıdır.");

        RuleFor(p => p.Power).NotNull().WithMessage("Araç motor gücü boş olamaz!");
        RuleFor(p => p.Power).NotEmpty().WithMessage("Araç motor gücü boş olamaz!");
        RuleFor(p => p.Power).GreaterThan(0).WithMessage("Araç motor gücü 0'dan büyük olmalıdır!");
        
    }
}