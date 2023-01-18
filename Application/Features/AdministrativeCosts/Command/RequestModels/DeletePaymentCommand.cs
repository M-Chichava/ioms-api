using Domain;
using MediatR;

namespace Application.Features.AdministrativeCosts.Command.RequestModels
{
    public class DeleteAdministrativeCostCommand : IRequest<AdministrativeCostAccount>
    {
        public int Id { get; set; }
    }
}