using Application.Features.UserOperationClaims.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.UserOperationClaims.Models
{
    public class UserOperationClaimListModal : BasePageableModel
    {
        public List<GetListUserOperationClaimDto> Items { get; set; }
    }
}
