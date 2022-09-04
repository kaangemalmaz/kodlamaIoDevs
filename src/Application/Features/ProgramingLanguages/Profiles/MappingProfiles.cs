using Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage;
using Application.Features.ProgramingLanguages.Commands.DeleteProgramingLanguage;
using Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage;
using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgramingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //    CreateMap<CreatedBrandDto, Brand>().ReverseMap();
            //    CreateMap<CreateBrandCommand, Brand>().ReverseMap();

            //    CreateMap<IPaginate<Brand>, BrandListModal>().ReverseMap();
            //    CreateMap<Brand, BrandListDto>().ReverseMap();

            CreateMap<ProgramingLanguageGetByIdDto, ProgramingLanguage>().ReverseMap();

            CreateMap<IPaginate<ProgramingLanguage>, ProgramingLanguageListModal>().ReverseMap();
            CreateMap<ProgramingLanguageGetListDto, ProgramingLanguage>().ReverseMap();

            CreateMap<CreatedProgramingLanguageDto, ProgramingLanguage>().ReverseMap();
            CreateMap<CreateProgramingLanguageCommand, ProgramingLanguage>().ReverseMap();

            CreateMap<UpdateProgramingLanguageCommand, ProgramingLanguage>().ReverseMap();
            CreateMap<UpdatedProgramingLanguageDto, ProgramingLanguage>().ReverseMap();

            CreateMap<DeleteProgramingLanguageCommand, ProgramingLanguage>().ReverseMap();
            CreateMap<DeletedProgramingLanguageDto, ProgramingLanguage>().ReverseMap();



        }
    }
}
