using Domain.Entities;
using FluentValidation;

namespace Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage
{
    public class UpdateProgramingLanguageCommandValidator : AbstractValidator<UpdateProgramingLanguageCommand>
    {
        public UpdateProgramingLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty()
                                .NotNull();
        }
    }
}
