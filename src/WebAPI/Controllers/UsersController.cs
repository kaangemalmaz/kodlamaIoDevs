using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Commands.DeleteUser;
using Application.Features.Users.Commands.UpdateUser;
using Application.Features.Users.Dtos;
using Application.Features.Users.Queries.GetByIdUser;
using Application.Features.Users.Queries.GetListUser;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateUserRequest createUser)
        {
            CreatedUserDto result = await Mediator.Send(createUser);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteUserRequest request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var request = new GetByIdUserRequest { Id = id };
            var result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var request = new GetListUserRequest { PageRequest= pageRequest };
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
