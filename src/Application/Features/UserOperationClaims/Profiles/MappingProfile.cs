using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserOperationClaimRequest, UserOperationClaim>().ReverseMap();
            CreateMap<CreatedUserOperationClaimDto, UserOperationClaim>().ReverseMap();

            CreateMap<UpdateUserOperationClaimRequest, UserOperationClaim>().ReverseMap();
            CreateMap<DeleteUserOperationClaimRequest, UserOperationClaim>().ReverseMap();

            CreateMap<GetByIdUserOperationClaimDto, UserOperationClaim>().ReverseMap();

            CreateMap<UserOperationClaimListModal, IPaginate<UserOperationClaim>>().ReverseMap();
            CreateMap<GetListUserOperationClaimDto, UserOperationClaim>().ReverseMap();

        }
    }
}
