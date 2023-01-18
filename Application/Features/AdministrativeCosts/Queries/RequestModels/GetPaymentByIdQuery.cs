using Domain;
using MediatR;

namespace Application.Features.AdministrativeCosts.Queries.RequestModels
{
    public class GetAdministrativeCostByIdQuery : IRequest<AdministrativeCostAccount>
    {
        public string NAdministrativeCost { get; set; }
    }
}