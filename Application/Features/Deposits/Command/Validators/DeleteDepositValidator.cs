using Domain;
using FluentValidation;

namespace Application.Features.Deposits.Command.Validators
{
    public class DeleteDepositValidator : AbstractValidator<Deposit>
    {
        public DeleteDepositValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}