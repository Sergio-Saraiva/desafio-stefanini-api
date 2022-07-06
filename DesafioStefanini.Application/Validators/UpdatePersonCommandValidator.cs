using DesafioStefanini.Application.Commands;
using FluentValidation;

namespace DesafioStefanini.Application.Validators
{
    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidator()
        {
            RuleFor(prop => prop.Id).NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null");

            RuleFor(prop => prop.Name).MinimumLength(3).WithMessage("{PropertyName} must have at leat 3 characters")
                .MaximumLength(300).WithMessage("{PropertyName} must have a maximum of 300 characters")
                .NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null");

            RuleFor(prop => prop.Cpf).MinimumLength(11).WithMessage("{PropertyName} must have at leat 11 characters")
                .MaximumLength(11).WithMessage("{PropertyName} must have a maximum of 11 characters")
                .NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null");

            RuleFor(prop => prop.Age).LessThan(170).WithMessage("{PropertyName} must be less than 170")
                .GreaterThan(0).WithMessage("{PropertyName} must be grater than 0")
                .NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null");

            RuleFor(p => p.CityUF).MinimumLength(2).WithMessage("{PropertyName} must have at leat 2 characters")
                .MaximumLength(2).WithMessage("{PropertyName} must have a maximum of 2 characters")
                .NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null");

            RuleFor(p => p.CityName).MinimumLength(2).WithMessage("{PropertyName} must have at leat 2 characters")
                .MaximumLength(200).WithMessage("{PropertyName} must have a maximum of 200 characters")
                .NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null");

        }
    }
}
