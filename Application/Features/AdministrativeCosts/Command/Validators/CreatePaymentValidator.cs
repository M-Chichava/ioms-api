using Application.Features.AdministrativeCosts.Command.RequestModels;
using FluentValidation;

namespace Application.Features.AdministrativeCosts.Command.Validators
{
    public class CreateAdministrativeCostValidator : AbstractValidator<CreateAdministrativeCostCommand>
    {
        public CreateAdministrativeCostValidator()
        {
            RuleFor(x => x.Amount).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.AccountNumber).NotEmpty();
        }
    }
}