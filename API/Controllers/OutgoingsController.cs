using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.Outgoings.Command.RequestModels;
using Application.Features.Outgoings.Queries.RequestModels;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OutgoingsController : BaseController
    {
        [HttpPost("add")]
        [Authorize(Roles = "AddOutgoing")]
        public async Task<ActionResult<OutgoingAccount>> AddOutgoingAccount(CreateOutgoingCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet("list")]
        [Authorize(Roles = "ListOutgoings")]
        public async Task<IReadOnlyList<OutgoingAccount>> ListOutgoings()
        {
            return await Mediator.Send(new ListAllOutgoingsQuery());
        } 
        
        [HttpGet("get/{id}")]
        [Authorize(Roles = "ListOutgoings")]
        public async Task<ActionResult<OutgoingAccount>> GetOutgoing(string id)
        {
            return await Mediator.Send(new GetOutgoingByIdQuery(){NOutgoing = id});
        } 
        
        [HttpDelete("remove/{id}")]
        [Authorize(Roles = "RemoveOutgoing")]
        public async Task<ActionResult<OutgoingAccount>> DeleteOutgoingAccount(int id)
        {
            return await Mediator.Send(new DeleteOutgoingCommand{Id = id});
        } 
        
        [HttpPut("Update/{id}")]
        [Authorize(Roles = "EditOutgoing")]
        public async Task<ActionResult<OutgoingAccount>> UpdateOutgoingAccount(int id, UpdateOutgoingCommand command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        } 
        
    }
}