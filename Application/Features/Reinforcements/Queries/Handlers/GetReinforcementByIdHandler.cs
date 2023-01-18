using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.Reinforcements.Queries.RequestModels; 
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR; 

namespace Application.Features.Reinforcements.Queries.Handlers
{
    public class GetReinforcementByIdHandler : IRequestHandler<GetReinforcementByIdQuery, ReinforcementAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetReinforcementByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ReinforcementAccount> Handle(GetReinforcementByIdQuery request, CancellationToken cancellationToken)
        {
            var reinforcementAccountSpecification = new ReinforcementAccountSpecification(request.NReinforcement);
            var reinforcementAccount =   await _unitOfWork.Repository<ReinforcementAccount>().GetEntityWithSpecAsync(reinforcementAccountSpecification);
            
            if (reinforcementAccount is null)
            {
                throw new ApiException(HttpStatusCode.NotFound,"Bank Account not Found in data base");
            }

            return reinforcementAccount; 
        }
    }
}