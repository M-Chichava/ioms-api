using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.BankAccounts.Queries.RequestModels;
using Application.Features.Payments.Queries.RequestModels;
using Application.Features.Users.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Payments.Queries.Handlers
{
    public class ListAllPaymentsHandler : IRequestHandler<ListAllPaymentsQuery, IReadOnlyList<PaymentAccount>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public ListAllPaymentsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper; 
        }
        public async Task<IReadOnlyList<PaymentAccount>> Handle(ListAllPaymentsQuery request, CancellationToken cancellationToken)
        {
            var paymentAccountSpecification = new PaymentAccountSpecification();
            var paymentAccounts = await _unitOfWork.Repository<PaymentAccount>()
                .ListAllWithSpecAsync(paymentAccountSpecification);
            var paymentAccountsList =  new List<PaymentAccount>();

            foreach (var paymentAccount in paymentAccounts)
            {
                paymentAccountsList.Add(paymentAccount);
                
            }
            return paymentAccountsList;
        }
    }
}