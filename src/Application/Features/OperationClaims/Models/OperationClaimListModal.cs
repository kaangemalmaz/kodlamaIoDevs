using Application.Features.OperationClaims.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.OperationClaims.Models
{
    public class OperationClaimListModal : BasePageableModel
    {
        public List<GetListOperationClaimDto> Items { get; set; }
    }
}
