using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Repositories;
using CashFlow.Exception.ExceptionsBase;
using CashFlow.Exception;
using CashFlow.Communication.Requests;
using CashFlow.Application.UseCases.Expenses.Register;

namespace CashFlow.Application.UseCases.Expenses.UpdateById;
public class UpdateExpenseByIdUseCase : IUpdateExpenseByIdUseCase
{
    private readonly IExpensesWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateExpenseByIdUseCase(
        IExpensesWriteOnlyRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id, RequestExpenseJson request)
    {
        Validate(request);

        var result = await _repository.Update(id);

        if (!result)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        await _unitOfWork.Commit();
    }

    private void Validate(RequestExpenseJson request)
    {
        var result = new UpdateExpenseByIdValidator().Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
