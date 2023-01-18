using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.Disbursements.Command.RequestModels;
using Application.Features.Disbursements.Queries.RequestModels;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DisbursementsController : BaseController
    {
        [HttpPost]
        [Authorize(Roles = "AddDisbursement")]
        public async Task<ActionResult<DisbursementAccount>> AddDisbursementAccount(CreateDisbursementCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet]
        [Authorize(Roles = "ListDisbursements")]
        public async Task<IReadOnlyList<DisbursementAccount>> ListDisbursements()
        {
            return await Mediator.Send(new ListAllDisbursementsQuery());
        } 
        
        [HttpGet("{id}")]
        [Authorize(Roles = "ListDisbursements")]
        public async Task<ActionResult<DisbursementAccount>> GetDisbursement(string id)
        {
            return await Mediator.Send(new GetDisbursementByIdQuery(){NDisbursement = id});
        } 
        
        [HttpDelete("remove/{id}")]
        [Authorize(Roles = "RemoveDisbursement")]
        public async Task<ActionResult<DisbursementAccount>> DeleteDisbursementAccount(int id)
        {
            return await Mediator.Send(new DeleteDisbursementCommand{Id = id});
        } 
        
        [HttpPut("Update/{id}")]
        [Authorize(Roles = "EditDisbursement")]
        public async Task<ActionResult<DisbursementAccount>> UpdateDisbursementAccount(int id, UpdateDisbursementCommand command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        } 
        
    }
}