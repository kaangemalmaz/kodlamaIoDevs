using Application.Services.Repositories;
using MediatR;

namespace Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(p=>p.Id == request.Id);
            if (user == null) throw new Exception("User bulunamadı!");

            await _userRepository.DeleteAsync(user);
            return Unit.Value;
        }
    }
}
