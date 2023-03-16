using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.Deposits.Command.RequestModels;
using Application.Features.Deposits.Queries.RequestModels;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DepositsController : BaseController
    {
        [HttpPost("add")]
        [Authorize(Roles = "AddDeposit")]
        public async Task<ActionResult<DepositAccount>> AddDepositAccount(CreateDepositCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet("list")]
        [Authorize(Roles = "ListDeposits")]
        public async Task<IReadOnlyList<DepositAccount>> ListDeposits()
        {
            return await Mediator.Send(new ListAllDepositsQuery());
        } 
        
        [HttpGet("get/{id}")]
        [Authorize(Roles = "ListDeposits")]
        public async Task<ActionResult<DepositAccount>> GetDeposit(string id)
        {
            return await Mediator.Send(new GetDepositByIdQuery(){NDeposit = id});
        } 
        
        [HttpDelete("remove/{id}")]
        [Authorize(Roles = "RemoveDeposit")]
        public async Task<ActionResult<DepositAccount>> DeleteDepositAccount(int id)
        {
            return await Mediator.Send(new DeleteDepositCommand{Id = id});
        } 
        
        [HttpPut("Update/{id}")]
        [Authorize(Roles = "EditDeposit")]
        public async Task<ActionResult<DepositAccount>> UpdateDepositAccount(int id, UpdateDepositCommand command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        } 
        
    }
}