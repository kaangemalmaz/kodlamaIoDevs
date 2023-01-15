using Application.Features.Users.Models;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Users.Queries.GetListUser
{
    public class GetListUserRequest : IRequest<UserListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
