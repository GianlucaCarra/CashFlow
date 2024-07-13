using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
    {
        try
        {
            var response = new RegisterExpenseUseCase().Execute(request);

            return Created(string.Empty, response);
        }
        catch (ArgumentException ex) 
        {
            var response = new ResponseErrorJson
            {
                ErrorMessage = ex.Message,
            };

            return BadRequest(response);
        }
        catch
        {
            var response = new ResponseErrorJson
            {
                ErrorMessage = "Unknow error",
            };

            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }
}
