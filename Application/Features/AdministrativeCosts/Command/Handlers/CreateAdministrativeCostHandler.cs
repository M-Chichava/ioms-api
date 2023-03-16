using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.AdministrativeCosts.Command.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.AdministrativeCosts.Command.Handlers
{
    public class CreateAdministrativeCostHandler : IRequestHandler<CreateAdministrativeCostCommand, AdministrativeCostAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAdministrativeCostHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AdministrativeCostAccount> Handle(CreateAdministrativeCostCommand request, CancellationToken cancellationToken)
        {
            var accountSpecification = new BankAccountSpecification(request.AccountNumber);
            var bankAccount = await _unitOfWork.Repository<BankAccount>().GetEntityWithSpecAsync(accountSpecification);

            if (bankAccount is null)
            {
                throw new ApiException(HttpStatusCode.Found,
                    "The specific bank account with entered account number doesn't exist on data base");

            }
            
            bankAccount.Balance += request.Amount;
            
            var administrativeCostDateTime = DateTime.Now;
            var administrativeCostDate = administrativeCostDateTime.ToString("yyyy-MM-dd hh:mm:ss");
            var auxNumber = new Random().Next(1000, 9999);
            
            var nAdministrativeCost = "ADC" + administrativeCostDateTime.Year + ""+ administrativeCostDateTime.Month+""+administrativeCostDateTime.Day+""+auxNumber;

            
            var administrativeCost = new AdministrativeCost
            {
                Description = request.Description,
                Amount = request.Amount
            };
            
            var administrativeCostBank = new AdministrativeCostAccount
            { 
                AdministrativeCost = administrativeCost,
                NAdministrativeCost = nAdministrativeCost,
                AdministrativeCostDate = administrativeCostDate,
                BankAccount = bankAccount
            };
            _unitOfWork.Repository<AdministrativeCost>().AddAsync(administrativeCost);
            _unitOfWork.Repository<AdministrativeCostAccount>().AddAsync(administrativeCostBank);
            
            var result = await _unitOfWork.Complete();
            
            if (result <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to add new bank account");
            }

            return administrativeCostBank;
        }
    }
}