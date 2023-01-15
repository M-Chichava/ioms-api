using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.BankAccounts.Command.RequestModels;
using Application.Features.BankAccounts.Queries.RequestModels;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BankAccountsController : BaseController
    {
        [HttpPost]
        [Authorize(Roles = "AddAccount")]
        public async Task<ActionResult<BankAccount>> AddBankAccount(CreateBankAccountCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet]
        [Authorize(Roles = "ListAccounts")]
        public async Task<IReadOnlyList<BankAccount>> ListBankAccounts()
        {
            return await Mediator.Send(new ListAllBankAccountsQuery());
        } 
        
        [HttpGet("{id}")]
        [Authorize(Roles = "ListAccounts")]
        public async Task<ActionResult<BankAccount>> GetBankAccount(int id)
        {
            return await Mediator.Send(new GetBankAccountByIdQuery(){Id = id});
        } 
        
        [HttpDelete("remove/{id}")]
        [Authorize(Roles = "RemoveAccount")]
        public async Task<ActionResult<BankAccount>> DeleteBankAccount(int id)
        {
            return await Mediator.Send(new DeleteBankAccountCommand{Id = id});
        } 
        
        [HttpPut("update/{id}")]
        [Authorize(Roles = "EditAccount")]
        public async Task<ActionResult<BankAccount>> UpdateBankAccount(int id, UpdateBankAccountCommand command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        } 
        
    }
}