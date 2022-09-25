using FluentValidation;

namespace Application.Features.Technologies.Commands.CreateTechnology
{
    public class UpdateTechnologyCommandValidator : AbstractValidator<CreateTechnologyCommand>
    {
        public UpdateTechnologyCommandValidator()
        {
            RuleFor(t => t.Name).NotEmpty().NotNull().WithMessage("Can not be empty or null");
            RuleFor(t => t.ProgramingLanguageId).NotEmpty().NotNull().WithMessage("Can not be empty or null");
        }
    }
}
