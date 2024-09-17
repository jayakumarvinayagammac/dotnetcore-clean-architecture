using ClassicModelApplication.DataTransferObjects;
using ClassicModelApplication.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassicModelApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : BaseController
{
    private readonly ILogger<CustomerController> _logger;
    public CustomerController(ILogger<CustomerController> logger, IMediator mediator)
        => (_logger, _mediator) = (logger, mediator); 

    [HttpGet]
    [Route("GetCustomerTransaction")]
    [ProducesResponseType<IEnumerable<CustomerTransactionDTO>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCustomerTransaction([FromQuery] int customerNumber)
    {
        try
        {
            var customerTransactions = await _mediator.Send(new GetCustomerOrderDetailQuery(customerNumber));
            return Ok(customerTransactions);
        }
        catch (Exception ex)
        {
            
            throw;
        }
    }
}