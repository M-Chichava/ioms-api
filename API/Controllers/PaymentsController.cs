using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.Payments.Command.RequestModels;
using Application.Features.Payments.Queries.RequestModels;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PaymentsController : BaseController
    {
        [HttpPost("add")]
        [Authorize(Roles = "AddPayment")]
        public async Task<ActionResult<PaymentAccount>> AddPaymentAccount(CreatePaymentCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet("list")]
        [Authorize(Roles = "ListPayments")]
        public async Task<IReadOnlyList<PaymentAccount>> ListPayments()
        {
            return await Mediator.Send(new ListAllPaymentsQuery());
        } 
        
        [HttpGet("get/{id}")]
        [Authorize(Roles = "ListPayments")]
        public async Task<ActionResult<PaymentAccount>> GetPayment(string id)
        {
            return await Mediator.Send(new GetPaymentByIdQuery(){NPayment = id});
        } 
        
        [HttpDelete("remove/{id}")]
        [Authorize(Roles = "RemovePayment")]
        public async Task<ActionResult<PaymentAccount>> DeletePaymentAccount(int id)
        {
            return await Mediator.Send(new DeletePaymentCommand{Id = id});
        } 
        
        [HttpPut("Update/{id}")]
        [Authorize(Roles = "EditPayment")]
        public async Task<ActionResult<PaymentAccount>> UpdatePaymentAccount(int id, UpdatePaymentCommand command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        } 
        
    }
}