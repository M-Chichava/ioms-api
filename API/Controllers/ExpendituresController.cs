using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.Expenditures.Command.RequestModels;
using Application.Features.Expenditures.Queries.RequestModels;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ExpendituresController : BaseController
    {
        [HttpPost("add")]
        [Authorize(Roles = "AddExpenditure")]
        public async Task<ActionResult<ExpenditureAccount>> AddExpenditureAccount(CreateExpenditureCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet("list")]
        [Authorize(Roles = "ListExpenditures")]
        public async Task<IReadOnlyList<ExpenditureAccount>> ListExpenditures()
        {
            return await Mediator.Send(new ListAllExpendituresQuery());
        } 
        
        [HttpGet("get/{id}")]
        [Authorize(Roles = "ListExpenditures")]
        public async Task<ActionResult<ExpenditureAccount>> GetExpenditure(string id)
        {
            return await Mediator.Send(new GetExpenditureByIdQuery(){NExpenditure = id});
        } 
        
        [HttpDelete("remove/{id}")]
        [Authorize(Roles = "RemoveExpenditure")]
        public async Task<ActionResult<ExpenditureAccount>> DeleteExpenditureAccount(int id)
        {
            return await Mediator.Send(new DeleteExpenditureCommand{Id = id});
        } 
        
        [HttpPut("Update/{id}")]
        [Authorize(Roles = "EditExpenditure")]
        public async Task<ActionResult<ExpenditureAccount>> UpdateExpenditureAccount(int id, UpdateExpenditureCommand command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        } 
        
    }
}