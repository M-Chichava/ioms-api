using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Features.Users.Commands.RequestModels;
using Application.Features.Users.Queries.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsersController : BaseController
    {
        [HttpPost("add")]
        [Authorize(Roles = "CreateUser")]
        public async Task<ActionResult<UserDto>> CreateUser(CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("list")]
        public async Task<IReadOnlyList<UserDto>> ListAllUsers()
        {
            return await Mediator.Send(new ListAllUsersQuery());
        }
        
        [HttpGet("current")]
        public async Task<UserDto> GetCurrentUser()
        {
            return await Mediator.Send(new GetCurrentUserQuery());
        }
        [HttpGet("get/{id}")]
        public async Task<UserDto> GetUser(string id)
        {
            return await Mediator.Send(new GetUserByIdQuery {Id = id});
        }
    }
}