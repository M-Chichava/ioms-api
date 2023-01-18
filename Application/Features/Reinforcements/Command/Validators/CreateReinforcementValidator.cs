using Application.Features.Reinforcements.Command.RequestModels;
using FluentValidation;

namespace Application.Features.Reinforcements.Command.Validators
{
    public class CreateReinforcementValidator : AbstractValidator<CreateReinforcementCommand>
    {
        public CreateReinforcementValidator()
        {
            RuleFor(x => x.Amount).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.AccountNumber).NotEmpty();
        }
    }
}