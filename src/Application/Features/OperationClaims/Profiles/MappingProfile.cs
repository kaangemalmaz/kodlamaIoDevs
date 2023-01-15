using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.OperationClaims.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateOperationClaimRequest, OperationClaim>().ReverseMap();
            CreateMap<CreatedOperationClaimDto, OperationClaim>().ReverseMap();

            CreateMap<UpdateOperationClaimRequest, OperationClaim>().ReverseMap();
            CreateMap<DeleteOperationClaimRequest, OperationClaim>().ReverseMap();

            CreateMap<GetByIdOperationClaimDto, OperationClaim>().ReverseMap();

            CreateMap<OperationClaimListModal, IPaginate<OperationClaim>>().ReverseMap();
            CreateMap<GetListOperationClaimDto, OperationClaim>().ReverseMap();

        }
    }
}
