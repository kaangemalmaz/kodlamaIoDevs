using Application.Features.Users.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreatedUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CreatedUserDto> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            byte[] passwordSalt, passwordHash;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

            var newUser = _mapper.Map<User>(request);
            newUser.PasswordSalt = passwordSalt;
            newUser.PasswordHash = passwordHash;

            var createdUser = await _userRepository.AddAsync(newUser);
            return _mapper.Map<CreatedUserDto>(createdUser);
        }
    }
}
