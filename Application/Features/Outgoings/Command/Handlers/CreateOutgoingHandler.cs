using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.Outgoings.Command.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.Outgoings.Command.Handlers
{
    public class CreateOutgoingHandler : IRequestHandler<CreateOutgoingCommand, OutgoingAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateOutgoingHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OutgoingAccount> Handle(CreateOutgoingCommand request, CancellationToken cancellationToken)
        {
            var accountSpecification = new BankAccountSpecification(request.AccountNumber);
            var bankAccount = await _unitOfWork.Repository<BankAccount>().GetEntityWithSpecAsync(accountSpecification);

            if (bankAccount is null)
            {
                throw new ApiException(HttpStatusCode.Found,
                    "The specific bank account with entered account number doesn't exist on data base");

            }
            
            bankAccount.Balance += request.Amount;
            
            var outgoingDateTime = DateTime.Now;
            var outgoingDate = outgoingDateTime.ToString("yyyy-MM-dd hh:mm:ss");
            var auxNumber = new Random().Next(1000, 9999);
            
            var nOutgoing = "PYT" + outgoingDateTime.Year + ""+ outgoingDateTime.Month+""+outgoingDateTime.Day+""+auxNumber;

            
            var outgoing = new Outgoing
            {
                Description = request.Description,
                Amount = request.Amount
            };
            
            var outgoingBank = new OutgoingAccount
            { 
                Outgoing = outgoing,
                NOutgoing = nOutgoing,
                OutgoingDate = outgoingDate,
                BankAccount = bankAccount
            };
            _unitOfWork.Repository<Outgoing>().AddAsync(outgoing);
            _unitOfWork.Repository<OutgoingAccount>().AddAsync(outgoingBank);
            
            var result = await _unitOfWork.Complete();
            
            if (result <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to add new bank account");
            }

            return outgoingBank;
        }
    }
}