using FluentValidation;

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommandValidator : AbstractValidator<DeleteTechnologyCommand>
    {
        public DeleteTechnologyCommandValidator()
        {
            RuleFor(t => t.Id).NotEmpty().NotNull().NotEqual(0).WithMessage("Id must!");
        }
    }
}
