using Domain;
using FluentValidation;

namespace Application.Features.BankAccounts.Command.Validators
{
    public class DeleteBankAccountValidator : AbstractValidator<BankAccount>
    {
        public DeleteBankAccountValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}