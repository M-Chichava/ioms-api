using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.LateInterests.Command.RequestModels;
using Application.Features.LateInterests.Queries.RequestModels;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class LateInterestsController : BaseController
    {
        [HttpPost("add")]
        [Authorize(Roles = "AddLateInterest")]
        public async Task<ActionResult<LateInterestAccount>> AddLateInterestAccount(CreateLateInterestCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet("list")]
        [Authorize(Roles = "ListLateInterests")]
        public async Task<IReadOnlyList<LateInterestAccount>> ListLateInterests()
        {
            return await Mediator.Send(new ListAllLateInterestsQuery());
        } 
        
        [HttpGet("get/{id}")]
        [Authorize(Roles = "ListLateInterests")]
        public async Task<ActionResult<LateInterestAccount>> GetLateInterest(string id)
        {
            return await Mediator.Send(new GetLateInterestByIdQuery(){NLateInterest = id});
        } 
        
        [HttpDelete("remove/{id}")]
        [Authorize(Roles = "RemoveLateInterest")]
        public async Task<ActionResult<LateInterestAccount>> DeleteLateInterestAccount(int id)
        {
            return await Mediator.Send(new DeleteLateInterestCommand{Id = id});
        } 
        
        [HttpPut("Update/{id}")]
        [Authorize(Roles = "EditLateInterest")]
        public async Task<ActionResult<LateInterestAccount>> UpdateLateInterestAccount(int id, UpdateLateInterestCommand command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        } 
        
    }
}