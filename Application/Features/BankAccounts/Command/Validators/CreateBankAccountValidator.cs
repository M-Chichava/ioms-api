using Application.Features.BankAccounts.Command.RequestModels;
using FluentValidation;

namespace Application.Features.BankAccounts.Command.Validators
{
    public class CreateBankAccountValidator : AbstractValidator<CreateBankAccountCommand>
    {
        public CreateBankAccountValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.AccountNumber).NotEmpty();
        }
    }
}