namespace CashFlow.Application.UseCases.Expenses.DeleteById;
public interface IDeleteExpenseByIdUseCase
{
    Task Execute(long id);
}
