using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.BankAccounts.Command.RequestModels;
using Application.Features.BankAccounts.Queries.RequestModels;
using Application.Features.Expenditures.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.Expenditures.Queries.Handlers
{
    public class GetExpenditureByIdHandler : IRequestHandler<GetExpenditureByIdQuery, ExpenditureAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetExpenditureByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ExpenditureAccount> Handle(GetExpenditureByIdQuery request, CancellationToken cancellationToken)
        {
            var expenditureAccountSpecification = new ExpenditureAccountSpecification(request.NExpenditure);
            var expenditureAccount =   await _unitOfWork.Repository<ExpenditureAccount>().GetEntityWithSpecAsync(expenditureAccountSpecification);
            
            if (expenditureAccount is null)
            {
                throw new ApiException(HttpStatusCode.NotFound,"Bank Account not Found in data base");
            }

            return expenditureAccount; 
        }
    }
}