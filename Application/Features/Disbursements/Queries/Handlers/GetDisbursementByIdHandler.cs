using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.BankAccounts.Command.RequestModels;
using Application.Features.BankAccounts.Queries.RequestModels;
using Application.Features.Disbursements.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.Disbursements.Queries.Handlers
{
    public class GetDisbursementByIdHandler : IRequestHandler<GetDisbursementByIdQuery, DisbursementAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDisbursementByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<DisbursementAccount> Handle(GetDisbursementByIdQuery request, CancellationToken cancellationToken)
        {
            var disbursementAccountSpecification = new DisbursementAccountSpecification(request.NDisbursement);
            var disbursementAccount =   await _unitOfWork.Repository<DisbursementAccount>().GetEntityWithSpecAsync(disbursementAccountSpecification);
            
            if (disbursementAccount is null)
            {
                throw new ApiException(HttpStatusCode.NotFound,"Bank Account not Found in data base");
            }

            return disbursementAccount; 
        }
    }
}