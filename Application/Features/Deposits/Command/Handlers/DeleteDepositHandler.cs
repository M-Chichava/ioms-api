using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.Deposits.Command.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.Deposits.Command.Handlers
{
    public class DeleteDepositHandler : IRequestHandler<DeleteDepositCommand, DepositAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDepositHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<DepositAccount> Handle(DeleteDepositCommand request, CancellationToken cancellationToken)
        {
           var DepositSpecification = new DepositSpecification(request.Id);
            var Deposit = await _unitOfWork.Repository<Deposit>().GetEntityWithSpecAsync(DepositSpecification);

            var DepositAccountSpecification = new DepositAccountSpecification(Deposit.Id, "");
            var DepositAccount = await _unitOfWork.Repository<DepositAccount>().GetEntityWithSpecAsync(DepositAccountSpecification);
            
            if (Deposit is null)
            {
                throw new ApiException(HttpStatusCode.NotFound, "The specified Deposit  was not found");
            }

            _unitOfWork.Repository<Deposit>().Delete(Deposit);
            _unitOfWork.Repository<DepositAccount>().Delete(DepositAccount);
            
            var response = await _unitOfWork.Complete();
            if (response <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to delete Bank Account");
            }
            return DepositAccount;
        }
    }
}