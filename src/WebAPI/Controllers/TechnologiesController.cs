using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.DeleteTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using Application.Features.Technologies.Queries.GetByIdTechnology;
using Application.Features.Technologies.Queries.GetListTechnology;
using Application.Features.Technologies.Queries.GetListTechnologyDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : BaseController
    {
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyQuery getListTechnologyQuery = new GetListTechnologyQuery { PageRequest = pageRequest };
            TechnologyListModel technologyListModel = await Mediator.Send(getListTechnologyQuery);
            return Ok(technologyListModel);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListTechnologyDynamicQuery getListTechnologyDynamicQuery = new GetListTechnologyDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            TechnologyListModel technologyListModel = await Mediator.Send(getListTechnologyDynamicQuery);
            return Ok(technologyListModel);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int Id)
        {
            GetByIdTechnologyQuery getByIdTechnologyQuery = new GetByIdTechnologyQuery { Id = Id };
            GetByIdTechnologyDto getByIdTechnologyDto = await Mediator.Send(getByIdTechnologyQuery);
            return Ok(getByIdTechnologyDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            CreatedTechnologyDto createdTechnologyDto = await Mediator.Send(createTechnologyCommand);
            return Ok(createdTechnologyDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] DeleteTechnologyCommand deleteTechnologyCommand)
        {
            DeletedTechnologyDto deletedTechnologyDto = await Mediator.Send(deleteTechnologyCommand);
            return Ok(deletedTechnologyDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
        {
            UpdatedTechnologyDto updatedTechnologyDto = await Mediator.Send(updateTechnologyCommand);
            return Ok(updatedTechnologyDto);
        }
    }
}
