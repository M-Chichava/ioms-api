using Domain;
using FluentValidation;

namespace Application.Features.Deposits.Command.Validators
{
    public class DeleteReinforcementValidator : AbstractValidator<Reinforcement>
    {
        public DeleteReinforcementValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}