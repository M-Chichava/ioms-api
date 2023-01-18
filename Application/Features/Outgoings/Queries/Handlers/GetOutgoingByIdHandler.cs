using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.BankAccounts.Command.RequestModels;
using Application.Features.BankAccounts.Queries.RequestModels;
using Application.Features.Outgoings.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.Outgoings.Queries.Handlers
{
    public class GetOutgoingByIdHandler : IRequestHandler<GetOutgoingByIdQuery, OutgoingAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOutgoingByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OutgoingAccount> Handle(GetOutgoingByIdQuery request, CancellationToken cancellationToken)
        {
            var outgoingAccountSpecification = new OutgoingAccountSpecification(request.NOutgoing);
            var outgoingAccount =   await _unitOfWork.Repository<OutgoingAccount>().GetEntityWithSpecAsync(outgoingAccountSpecification);
            
            if (outgoingAccount is null)
            {
                throw new ApiException(HttpStatusCode.NotFound,"Bank Account not Found in data base");
            }

            return outgoingAccount; 
        }
    }
}