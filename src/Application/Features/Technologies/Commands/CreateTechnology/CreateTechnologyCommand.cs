using Application.Features.Technologies.Dtos;
using MediatR;

namespace Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommand : IRequest<CreatedTechnologyDto>
    {
        public int ProgramingLanguageId { get; set; }
        public string Name { get; set; }
    }
}
