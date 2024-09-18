using ClassicModelApplication.Commands;
using ClassicModelApplication.DataTransferObjects;
using ClassicModelApplication.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassicModelApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OfficeController : BaseController
{
    private readonly ILogger<CustomerController> _logger;
    public OfficeController(ILogger<CustomerController> logger, IMediator mediator)
        => (_logger, _mediator) = (logger, mediator); 

    [HttpGet]
    [Route("GetOffice")]
    [ProducesResponseType<IEnumerable<OfficeDTO>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetOffice()
    {
        try
        {
            var offices = await _mediator.Send(new GetOfficeQuery());
            return Ok(offices);
        }
        catch (Exception ex)
        {
            
            throw;
        }
    }

    [HttpPost]    
    [Route("CreateOffice")]        
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateOffice([FromBody] OfficeDTO office)
    {
        try
        {
            var officeCode = await _mediator.Send(new CreateOfficeCommand(office));
            return Ok(officeCode);    
        }
        catch (System.Exception)
        {
            
            throw;
        }        
    }

    [HttpDelete]
    [Route("RemoveOffice")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteOffice(string officeCode)
    {
        try
        {
            var removeResultOfficeCode = await _mediator.Send(new RemoveOfficeCommand(officeCode));
            return Ok(removeResultOfficeCode);
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
    
}