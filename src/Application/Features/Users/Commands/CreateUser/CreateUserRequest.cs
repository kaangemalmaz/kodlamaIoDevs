using Application.Features.Users.Dtos;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserRequest : IRequest<CreatedUserDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
