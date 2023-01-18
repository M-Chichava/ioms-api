using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.Reinforcements.Command.RequestModels;
using Application.Features.Reinforcements.Queries.RequestModels;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ReinforcementsController : BaseController
    {
        [HttpPost]
        [Authorize(Roles = "AddReinforcement")]
        public async Task<ActionResult<ReinforcementAccount>> AddReinforcementAccount(CreateReinforcementCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet]
        [Authorize(Roles = "ListReinforcements")]
        public async Task<IReadOnlyList<ReinforcementAccount>> ListReinforcements()
        {
            return await Mediator.Send(new ListAllReinforcementsQuery());
        } 
        
        [HttpGet("{id}")]
        [Authorize(Roles = "ListReinforcements")]
        public async Task<ActionResult<ReinforcementAccount>> GetReinforcement(string id)
        {
            return await Mediator.Send(new GetReinforcementByIdQuery(){NReinforcement = id});
        } 
        
        [HttpDelete("remove/{id}")]
        [Authorize(Roles = "RemoveReinforcement")]
        public async Task<ActionResult<ReinforcementAccount>> DeleteReinforcementAccount(int id)
        {
            return await Mediator.Send(new DeleteReinforcementCommand{Id = id});
        } 
        
        [HttpPut("Update/{id}")]
        [Authorize(Roles = "EditReinforcement")]
        public async Task<ActionResult<ReinforcementAccount>> UpdateReinforcementAccount(int id, UpdateReinforcementCommand command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        } 
        
    }
}