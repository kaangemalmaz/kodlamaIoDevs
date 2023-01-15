using Application.Features.Users.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Queries.GetListUser
{
    public class GetListUserHandler : IRequestHandler<GetListUserRequest, UserListModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetListUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserListModel> Handle(GetListUserRequest request, CancellationToken cancellationToken)
        {
            IPaginate<User> UserList  = await _userRepository.GetListAsync(
                include: p => p.Include(p => p.UserOperationClaims),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);
            
            return _mapper.Map<UserListModel>(UserList);

        }
    }
}
