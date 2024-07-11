using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.UpdateById;
public class UpdateExpenseByIdValidator : AbstractValidator<RequestExpenseJson>
{
    public UpdateExpenseByIdValidator()
    {
        RuleFor(e => e.Title).NotEmpty().WithMessage(ResourceErrorMessages.TITLE_REQUIRED);
        RuleFor(e => e.Amount).GreaterThan(0).WithMessage(ResourceErrorMessages.AMOUNT_MUST_BE_GREATHER_THAN_ZERO);
        RuleFor(e => e.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.EXPENSES_CANNOT_BE_FUTURE);
        RuleFor(e => e.PaymentType).IsInEnum().WithMessage(ResourceErrorMessages.INVALID_PAYMENT_TYPE);
    }
}