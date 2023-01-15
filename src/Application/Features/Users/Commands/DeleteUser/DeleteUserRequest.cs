using MediatR;

namespace Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserRequest : IRequest
    {
        public int Id { get; set; }
    }
}
