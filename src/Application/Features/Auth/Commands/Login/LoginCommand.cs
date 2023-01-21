using Application.Features.Auth.Dtos;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<LoginedDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAdress { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginedDto>
        {
            private readonly IAuthService _authService;
            private readonly IUserRepository _userRepository;

            public LoginCommandHandler(IAuthService authService, IUserRepository userRepository)
            {
                _authService = authService;
                _userRepository = userRepository;
            }

            public async Task<LoginedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {

                User? user =  await _userRepository.GetAsync(p=>p.Email.ToLower() == request.UserForLoginDto.Email.ToLower());
                if (user == null) throw new BusinessException("User not found");

                var result = HashingHelper.VerifyPasswordHash(request.UserForLoginDto.Password, user.PasswordHash, user.PasswordSalt);
                if (!result) throw new BusinessException("Password is wrong!");

                AccessToken createdAccessToken = await _authService.CreateAccessToken(user);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAdress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                LoginedDto loginedDto = new()
                {
                    AccessToken = createdAccessToken,
                    RefreshToken = addedRefreshToken,
                };

                return loginedDto;

            }
        }
    }
}
