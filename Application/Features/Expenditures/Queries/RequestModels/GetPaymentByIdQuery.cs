using Domain;
using MediatR;

namespace Application.Features.Expenditures.Queries.RequestModels
{
    public class GetExpenditureByIdQuery : IRequest<ExpenditureAccount>
    {
        public string NExpenditure { get; set; }
    }
}