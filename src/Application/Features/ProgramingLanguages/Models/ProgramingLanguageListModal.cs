using Application.Features.ProgramingLanguages.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.ProgramingLanguages.Models
{
    public class ProgramingLanguageListModal : BasePageableModel
    {
        public List<ProgramingLanguageGetListDto> Items { get; set; }
    }
}
