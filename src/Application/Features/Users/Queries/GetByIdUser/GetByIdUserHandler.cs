using Application.Features.Users.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Queries.GetByIdUser
{
    public class GetByIdUserHandler : IRequestHandler<GetByIdUserRequest, GetByIdUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetByIdUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdUserDto> Handle(GetByIdUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(p=>p.Id== request.Id);
            if (user == null) throw new Exception("User bulunamadı!");
            GetByIdUserDto getByIdUserDto = _mapper.Map<GetByIdUserDto>(user);
            return getByIdUserDto;
        }
    }
}
