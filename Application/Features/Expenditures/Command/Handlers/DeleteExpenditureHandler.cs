using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.Expenditures.Command.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.Expenditures.Command.Handlers
{
    public class DeleteExpenditureHandler : IRequestHandler<DeleteExpenditureCommand, ExpenditureAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteExpenditureHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ExpenditureAccount> Handle(DeleteExpenditureCommand request, CancellationToken cancellationToken)
        {
           var expenditureSpecification = new ExpenditureSpecification(request.Id);
            var expenditure = await _unitOfWork.Repository<Expenditure>().GetEntityWithSpecAsync(expenditureSpecification);

            var expenditureAccountSpecification = new ExpenditureAccountSpecification(expenditure.Id, "");
            var expenditureAccount = await _unitOfWork.Repository<ExpenditureAccount>().GetEntityWithSpecAsync(expenditureAccountSpecification);
            
            if (expenditure is null)
            {
                throw new ApiException(HttpStatusCode.NotFound, "The specified Expenditure  was not found");
            }

            _unitOfWork.Repository<Expenditure>().Delete(expenditure);
            _unitOfWork.Repository<ExpenditureAccount>().Delete(expenditureAccount);
            
            var response = await _unitOfWork.Complete();
            if (response <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to delete Bank Account");
            }
            return expenditureAccount;
        }
    }
}