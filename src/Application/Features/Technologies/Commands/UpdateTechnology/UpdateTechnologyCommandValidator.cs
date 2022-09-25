using FluentValidation;

namespace Application.Features.Technologies.Commands.UpdateTechnology
{
    public class DeleteTechnologyCommandValidator : AbstractValidator<UpdateTechnologyCommand>
    {
        public DeleteTechnologyCommandValidator()
        {
            RuleFor(t => t.Id).NotEmpty().NotNull().NotEqual(0).WithMessage("Id must!");
            RuleFor(t => t.Name).NotEmpty().NotNull().WithMessage("Can not be empty or null");
            RuleFor(t => t.ProgramingLanguageId).NotEmpty().NotNull().NotEqual(0).WithMessage("Can not be empty or null");
        }
    }
}
