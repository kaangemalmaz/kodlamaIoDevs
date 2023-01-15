using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.Users.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, CreateUserRequest>().ReverseMap();
            CreateMap<CreatedUserDto, User>().ReverseMap();

            CreateMap<GetByIdUserDto, User>().ReverseMap();

            CreateMap<GetListUserDto, User>().ReverseMap();
            CreateMap<UserListModel, IPaginate<User>>().ReverseMap();
        }
    }
}
