using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.ApplicationRoles.Commands.RequestModels;
using Application.Features.ApplicationRoles.Queries.RequestModels;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ApplicationRolesController : BaseController
    {
        [HttpPost("add")]
        [Authorize(Roles = "AddRole")]
        public async Task<ActionResult<ApplicationRole>> AddRoles(AddRoleCommand command)
        {
            return await Mediator.Send(command);
        }
        
        [HttpGet("list")]
        [Authorize(Roles = "ListRoles")]
        public async Task<IReadOnlyList<ApplicationRole>> ListRoles()
        {
            return await Mediator.Send(new ListRolesQuery());
        }

        [HttpDelete("remove/{id}")]
        [Authorize(Roles = "RemoveRole")]
        public async Task<ActionResult<ApplicationRole>> RemoveRole(int id)
        {
            return await Mediator.Send(new RemoveRoleCommand {Id = id});
        }
    }
}