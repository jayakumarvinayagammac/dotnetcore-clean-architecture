
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassicModelApi.Controllers;

public abstract class BaseController : ControllerBase
{
    protected IMediator _mediator;         
}