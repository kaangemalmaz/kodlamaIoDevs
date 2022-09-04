using Domain.Entities;
using FluentValidation;

namespace Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage
{
    public class CreateProgramingLanguageCommandValidator : AbstractValidator<CreateProgramingLanguageCommand>
    {
        public CreateProgramingLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty()
                                .NotNull()
                                .MinimumLength(3);
        }
    }
}
