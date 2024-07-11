using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Get;
public interface IGetExpenseByIdUseCase
{
    Task<ResponseExpenseJson> Execute(long id);
}
