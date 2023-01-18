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
    public class UpdateAdministrativeCostHandler : IRequestHandler<UpdateAdministrativeCostCommand, AdministrativeCostAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAdministrativeCostHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AdministrativeCostAccount> Handle(UpdateAdministrativeCostCommand request, CancellationToken cancellationToken)
        {

            var administrativeCostAccountSpecification = new AdministrativeCostAccountSpecification(request.Id);
            var administrativeCostAccount = await _unitOfWork.Repository<AdministrativeCostAccount>().GetEntityWithSpecAsync(administrativeCostAccountSpecification);
            var administrativeCost = administrativeCostAccount.AdministrativeCost;

            var oldBankAccountSpecification = new BankAccountSpecification(administrativeCostAccount.BankAccount.AccountNumber);
            var oldbankAccount = await _unitOfWork.Repository<BankAccount>().GetEntityWithSpecAsync(oldBankAccountSpecification);
            
            if (request.AccountNumber > 0 && request.AccountNumber.ToString().Length >= 8)
            {
                administrativeCostAccount.BankAccount.AccountNumber = request.AccountNumber;
                
                oldbankAccount.Balance -= administrativeCost.Amount;

            }
            
            if (request.Description is not null)
            {
                administrativeCost.Description = request.Description;
            }
            
            administrativeCostAccount.BankAccount.Balance += request.Amount + administrativeCost.Amount;
            if (request.Amount > 0)
            {
                administrativeCost.Amount = request.Amount;
            }
                
            
            _unitOfWork.Repository<AdministrativeCost>().Update(administrativeCost);
            _unitOfWork.Repository<AdministrativeCostAccount>().Update(administrativeCostAccount);

            var response = await _unitOfWork.Complete();

            if (response <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to Update AdministrativeCost");
            }

            return administrativeCostAccount;
        }
    }
}