using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.Outgoings.Command.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.Outgoings.Command.Handlers
{
    public class DeleteOutgoingHandler : IRequestHandler<DeleteOutgoingCommand, OutgoingAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOutgoingHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OutgoingAccount> Handle(DeleteOutgoingCommand request, CancellationToken cancellationToken)
        {
           var outgoingSpecification = new OutgoingSpecification(request.Id);
            var outgoing = await _unitOfWork.Repository<Outgoing>().GetEntityWithSpecAsync(outgoingSpecification);

            var outgoingAccountSpecification = new OutgoingAccountSpecification(outgoing.Id, "");
            var outgoingAccount = await _unitOfWork.Repository<OutgoingAccount>().GetEntityWithSpecAsync(outgoingAccountSpecification);
            
            if (outgoing is null)
            {
                throw new ApiException(HttpStatusCode.NotFound, "The specified Outgoing  was not found");
            }

            _unitOfWork.Repository<Outgoing>().Delete(outgoing);
            _unitOfWork.Repository<OutgoingAccount>().Delete(outgoingAccount);
            
            var response = await _unitOfWork.Complete();
            if (response <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to delete Bank Account");
            }
            return outgoingAccount;
        }
    }
}