using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.AdministrativeCosts.Command.RequestModels;
using Application.Features.AdministrativeCosts.Queries.RequestModels;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AdministrativeCostsController : BaseController
    {
        [HttpPost("add")]
        [Authorize(Roles = "AddAdministrativeCost")]
        public async Task<ActionResult<AdministrativeCostAccount>> AddAdministrativeCostAccount(CreateAdministrativeCostCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet("list")]
        [Authorize(Roles = "ListAdministrativeCosts")]
        public async Task<IReadOnlyList<AdministrativeCostAccount>> ListAdministrativeCosts()
        {
            return await Mediator.Send(new ListAllAdministrativeCostsQuery());
        } 
        
        [HttpGet("get/{id}")]
        [Authorize(Roles = "ListAdministrativeCosts")]
        public async Task<ActionResult<AdministrativeCostAccount>> GetAdministrativeCost(string id)
        {
            return await Mediator.Send(new GetAdministrativeCostByIdQuery(){NAdministrativeCost = id});
        } 
        
        [HttpDelete("remove/{id}")]
        [Authorize(Roles = "RemoveAdministrativeCost")]
        public async Task<ActionResult<AdministrativeCostAccount>> DeleteAdministrativeCostAccount(int id)
        {
            return await Mediator.Send(new DeleteAdministrativeCostCommand{Id = id});
        } 
        
        [HttpPut("Update/{id}")]
        [Authorize(Roles = "EditAdministrativeCost")]
        public async Task<ActionResult<AdministrativeCostAccount>> UpdateAdministrativeCostAccount(int id, UpdateAdministrativeCostCommand command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        } 
        
    }
}