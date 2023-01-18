using Domain;
using FluentValidation;

namespace Application.Features.Outgoings.Command.Validators
{
    public class DeleteOutgoingValidator : AbstractValidator<Outgoing>
    {
        public DeleteOutgoingValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}