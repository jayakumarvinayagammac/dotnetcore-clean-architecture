using ClassicModelApplication.DataTransferObjects;
using ClassicModelApplication.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassicModelApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{    
    private readonly ILogger<OrderController> _logger;
     private readonly IMediator _mediator;    

    public OrderController(ILogger<OrderController> logger, IMediator mediator)
        => (_logger, _mediator) = (logger, mediator);         

    [HttpGet(Name = "GetOrderDetail")]
    [ProducesResponseType<IEnumerable<OrderDetailDTO>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        try
        {
            await Task.Delay(100);
            _logger.LogInformation("OrderController - GetOrderDetail requested");
            var orderDetails = _mediator.Send(new GetOrderDetailQuery());
            _logger.LogInformation("OrderController - GetOrderDetail executed and response shared");
            return Ok(orderDetails);    
        }
        catch (System.Exception)
        {
            throw;
        }
        
    }
}
