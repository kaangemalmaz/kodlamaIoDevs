using Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage;
using Application.Features.ProgramingLanguages.Commands.DeleteProgramingLanguage;
using Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage;
using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Models;
using Application.Features.ProgramingLanguages.Queries.GetByIdProgramingLanguage;
using Application.Features.ProgramingLanguages.Queries.GetListProgramingLanguage;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramingLanguagesController : BaseController
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgramingLanguageQuery getByIdProgramingLanguageQuery)
        {
            ProgramingLanguageGetByIdDto programingLanguageGetByIdDto = await Mediator.Send(getByIdProgramingLanguageQuery);

            return Ok(programingLanguageGetByIdDto);
        }


        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgramingLanguageQuery getListProgramingLanguageQuery = new() { PageRequest = pageRequest };

            ProgramingLanguageListModal programingLanguageListModal = await Mediator.Send(getListProgramingLanguageQuery);

            return Ok(programingLanguageListModal);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgramingLanguageCommand createProgramingLanguageCommand)
        {
           CreatedProgramingLanguageDto createdProgramingLanguageDto = await Mediator.Send(createProgramingLanguageCommand);

            return Created("", createdProgramingLanguageDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgramingLanguageCommand updateProgramingLanguageCommand)
        {
            UpdatedProgramingLanguageDto updatedProgramingLanguageDto = await Mediator.Send(updateProgramingLanguageCommand);

            return Ok(updatedProgramingLanguageDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            DeleteProgramingLanguageCommand deleteProgramingLanguageCommand = new() { Id = id };

            DeletedProgramingLanguageDto deletedProgramingLanguageDto = await Mediator.Send(deleteProgramingLanguageCommand);

            return Ok(deletedProgramingLanguageDto);
        }
    }
}
