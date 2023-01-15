using Application.Features.Users.Dtos;
using MediatR;

namespace Application.Features.Users.Queries.GetByIdUser
{
    public class GetByIdUserRequest : IRequest<GetByIdUserDto>
    {
        public int Id { get; set; }
    }
}
