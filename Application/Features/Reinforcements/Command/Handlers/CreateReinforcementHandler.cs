using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.Reinforcements.Command.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.Reinforcements.Command.Handlers
{
    public class CreateReinforcementHandler : IRequestHandler<CreateReinforcementCommand, ReinforcementAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateReinforcementHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ReinforcementAccount> Handle(CreateReinforcementCommand request, CancellationToken cancellationToken)
        {
            var accountSpecification = new BankAccountSpecification(request.AccountNumber);
            var bankAccount = await _unitOfWork.Repository<BankAccount>().GetEntityWithSpecAsync(accountSpecification);

            if (bankAccount is null)
            {
                throw new ApiException(HttpStatusCode.Found,
                    "The specific bank account with entered account number doesn't exist ondata base");

            }
            
            bankAccount.Balance += request.Amount;
            
            var reinforcementDateTime = DateTime.Now;
            var reinforcementDate = reinforcementDateTime.ToString("yyyy-MM-dd hh:mm:ss");
            var auxNumber = new Random().Next(1000, 9999);
            
            var nReinforcement = "PYT" + reinforcementDateTime.Year + ""+ reinforcementDateTime.Month+""+ reinforcementDateTime.Day+""+auxNumber;

            
            var reinforcement = new Reinforcement
            {
                Description = request.Description,
                Amount = request.Amount
            };
            
            var reinforcementBank = new ReinforcementAccount
            { 
                Reinforcement = reinforcement,
                NReinforcement = nReinforcement,
                ReinforcementDate = reinforcementDate,
                BankAccount = bankAccount
            };
            _unitOfWork.Repository<Reinforcement>().AddAsync(reinforcement);
            _unitOfWork.Repository<ReinforcementAccount>().AddAsync( reinforcementBank);
            
            var result = await _unitOfWork.Complete();
            
            if (result <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to add new bank account");
            }

            return reinforcementBank;
        }
    }
}