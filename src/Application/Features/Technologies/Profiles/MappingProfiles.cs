using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.DeleteTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Technologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //getall
            CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
            CreateMap<Technology, GetListTechnologyDto>().ForMember(t => t.ProgramingLanguageName, t => t.MapFrom(t => t.ProgramingLanguage.Name)).ReverseMap();

            //getbyid
            CreateMap<Technology, GetByIdTechnologyDto>().ForMember(t => t.ProgramingLanguageName, t => t.MapFrom(t => t.ProgramingLanguage.Name)).ReverseMap();

            //add
            CreateMap<Technology, CreatedTechnologyDto>().ReverseMap();
            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();

            //delete
            CreateMap<DeletedTechnologyDto, Technology>().ReverseMap();
            CreateMap<DeleteTechnologyCommand, Technology>().ReverseMap();

            //update
            CreateMap<UpdatedTechnologyDto, Technology>().ReverseMap();
            CreateMap<UpdateTechnologyCommand, Technology>().ReverseMap();
        }
    }
}
