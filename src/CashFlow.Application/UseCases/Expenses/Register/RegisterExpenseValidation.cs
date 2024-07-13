using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseValidation : AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpenseValidation()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage("The title is required.");
        RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage("The amount must be greather than zero.");
        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Expenses can't be for the future");
        RuleFor(expense => expense.Type).IsInEnum().WithMessage("Invalid payment type");  
    }
}
