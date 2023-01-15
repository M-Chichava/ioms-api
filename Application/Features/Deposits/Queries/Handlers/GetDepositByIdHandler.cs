using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.Deposits.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.Deposits.Queries.Handlers
{
    public class GetDepositByIdHandler : IRequestHandler<GetDepositByIdQuery, DepositAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDepositByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<DepositAccount> Handle(GetDepositByIdQuery request, CancellationToken cancellationToken)
        {
            var depositAccountSpecification = new DepositAccountSpecification(request.NDeposit);
            var depositAccount =   await _unitOfWork.Repository<DepositAccount>().GetEntityWithSpecAsync(depositAccountSpecification);
            
            if (depositAccount is null)
            {
                throw new ApiException(HttpStatusCode.NotFound,"Bank Account not Found in data base");
            }

            return depositAccount; 
        }
    }
}