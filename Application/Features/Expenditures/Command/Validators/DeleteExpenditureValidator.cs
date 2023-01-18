using Domain;
using FluentValidation;

namespace Application.Features.Expenditures.Command.Validators
{
    public class DeleteExpenditureValidator : AbstractValidator<Expenditure>
    {
        public DeleteExpenditureValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}