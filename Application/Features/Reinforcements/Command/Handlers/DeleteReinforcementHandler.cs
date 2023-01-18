using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.Reinforcements.Command.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.Reinforcements.Command.Handlers
{
    public class DeleteReinforcementHandler : IRequestHandler<DeleteReinforcementCommand, ReinforcementAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteReinforcementHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ReinforcementAccount> Handle(DeleteReinforcementCommand request, CancellationToken cancellationToken)
        {
           var reinforcementSpecification = new ReinforcementSpecification(request.Id);
            var reinforcement = await _unitOfWork.Repository<Reinforcement>().GetEntityWithSpecAsync(reinforcementSpecification);

            var reinforcementAccountSpecification = new ReinforcementAccountSpecification(reinforcement.Id, "");
            var reinforcementAccount = await _unitOfWork.Repository<ReinforcementAccount>().GetEntityWithSpecAsync(reinforcementAccountSpecification);
            
            if (reinforcement is null)
            {
                throw new ApiException(HttpStatusCode.NotFound, "The specified reinforcement  was not found");
            }

            _unitOfWork.Repository<Reinforcement>().Delete(reinforcement);
            _unitOfWork.Repository<ReinforcementAccount>().Delete(reinforcementAccount);
            
            var response = await _unitOfWork.Complete();
            if (response <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to delete Bank Account");
            }
            return reinforcementAccount;
        }
    }
}