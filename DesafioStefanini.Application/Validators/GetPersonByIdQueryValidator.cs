using DesafioStefanini.Application.Queries;
using FluentValidation;

namespace DesafioStefanini.Application.Validators
{
    public class GetPersonByIdQueryValidator : AbstractValidator<GetPersonByIdQuery>
    {
        public GetPersonByIdQueryValidator()
        {
            RuleFor(prop => prop.Id).NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null");
        }
    }
}
