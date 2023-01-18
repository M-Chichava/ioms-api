using Domain;
using MediatR;

namespace Application.Features.Expenditures.Command.RequestModels
{
    public class UpdateExpenditureCommand : IRequest<ExpenditureAccount>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public long AccountNumber { get; set; }
    }
}