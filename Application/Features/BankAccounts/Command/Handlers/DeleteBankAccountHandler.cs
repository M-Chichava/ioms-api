using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.BankAccounts.Command.RequestModels;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.BankAccounts.Command.Handlers
{
    public class DeleteBankAccountHandler : IRequestHandler<DeleteBankAccountCommand, BankAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBankAccountHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BankAccount> Handle(DeleteBankAccountCommand request, CancellationToken cancellationToken)
        {
            var bankAccount = await _unitOfWork.Repository<BankAccount>().GetByIdAsync(request.Id);

            if (bankAccount is null)
            {
                throw new ApiException(HttpStatusCode.NotFound, "The specified Bank Account was not found");
            }

            _unitOfWork.Repository<BankAccount>().Delete(bankAccount);
            var response = await _unitOfWork.Complete();
            if (response <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to delete Bank Account");
            }
            return bankAccount;
        }
    }
}