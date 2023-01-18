using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.Deposits.Command.RequestModels;
using Application.Features.Reinforcements.Command.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.Reinforcements.Command.Handlers
{
    public class UpdateReinforcementHandler : IRequestHandler<UpdateReinforcementCommand, ReinforcementAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateReinforcementHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ReinforcementAccount> Handle(UpdateReinforcementCommand request, CancellationToken cancellationToken)
        {

            var reinforcementAccountSpecification = new ReinforcementAccountSpecification(request.Id);
            var reinforcementAccount = await _unitOfWork.Repository<ReinforcementAccount>().GetEntityWithSpecAsync(reinforcementAccountSpecification);
            var reinforcement = reinforcementAccount.Reinforcement;

            var oldBankAccountSpecification = new BankAccountSpecification(reinforcementAccount.BankAccount.AccountNumber);
            var oldbankAccount = await _unitOfWork.Repository<BankAccount>().GetEntityWithSpecAsync(oldBankAccountSpecification);
            
            if (request.AccountNumber > 0 && request.AccountNumber.ToString().Length >= 8)
            {
                reinforcementAccount.BankAccount.AccountNumber = request.AccountNumber;
                
                oldbankAccount.Balance -= reinforcement.Amount;

            }
            
            if (request.Description is not null)
            {
                reinforcement.Description = request.Description;
            }
            
            reinforcementAccount.BankAccount.Balance += request.Amount + reinforcement.Amount;
            if (request.Amount > 0)
            {
                reinforcement.Amount = request.Amount;
            }
                
            
            _unitOfWork.Repository<Reinforcement>().Update(reinforcement);
            _unitOfWork.Repository<ReinforcementAccount>().Update(reinforcementAccount);

            var response = await _unitOfWork.Complete();

            if (response <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to Update Deposit");
            }

            return reinforcementAccount;
        }
    }
}