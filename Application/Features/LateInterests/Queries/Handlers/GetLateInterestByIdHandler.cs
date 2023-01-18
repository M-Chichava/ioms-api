using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.LateInterests.Queries.RequestModels; 
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR; 

namespace Application.Features.LateInterests.Queries.Handlers
{
    public class GetLateInterestByIdHandler : IRequestHandler<GetLateInterestByIdQuery, LateInterestAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetLateInterestByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<LateInterestAccount> Handle(GetLateInterestByIdQuery request, CancellationToken cancellationToken)
        {
            var lateInterestAccountSpecification = new LateInterestAccountSpecification(request.NLateInterest);
            var lateInterestAccount =   await _unitOfWork.Repository<LateInterestAccount>().GetEntityWithSpecAsync(lateInterestAccountSpecification);
            
            if (lateInterestAccount is null)
            {
                throw new ApiException(HttpStatusCode.NotFound,"Bank Account not Found in data base");
            }

            return lateInterestAccount; 
        }
    }
}