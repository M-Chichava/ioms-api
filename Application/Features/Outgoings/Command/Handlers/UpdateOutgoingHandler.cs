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
    public class UpdateOutgoingHandler : IRequestHandler<UpdateOutgoingCommand, OutgoingAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOutgoingHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OutgoingAccount> Handle(UpdateOutgoingCommand request, CancellationToken cancellationToken)
        {

            var outgoingAccountSpecification = new OutgoingAccountSpecification(request.Id);
            var outgoingAccount = await _unitOfWork.Repository<OutgoingAccount>().GetEntityWithSpecAsync(outgoingAccountSpecification);
            var outgoing = outgoingAccount.Outgoing;

            var oldBankAccountSpecification = new BankAccountSpecification(outgoingAccount.BankAccount.AccountNumber);
            var oldbankAccount = await _unitOfWork.Repository<BankAccount>().GetEntityWithSpecAsync(oldBankAccountSpecification);
            
            if (request.AccountNumber > 0 && request.AccountNumber.ToString().Length >= 8)
            {
                outgoingAccount.BankAccount.AccountNumber = request.AccountNumber;
                
                oldbankAccount.Balance -= outgoing.Amount;

            }
            
            if (request.Description is not null)
            {
                outgoing.Description = request.Description;
            }
            
            outgoingAccount.BankAccount.Balance += request.Amount + outgoing.Amount;
            if (request.Amount > 0)
            {
                outgoing.Amount = request.Amount;
            }
                
            
            _unitOfWork.Repository<Outgoing>().Update(outgoing);
            _unitOfWork.Repository<OutgoingAccount>().Update(outgoingAccount);

            var response = await _unitOfWork.Complete();

            if (response <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to Update Outgoing");
            }

            return outgoingAccount;
        }
    }
}