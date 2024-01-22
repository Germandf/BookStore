using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Common;

[ApiController]
[Route("api/", Name = "Api")]
public abstract class ApiControllerBase : ControllerBase
{
    protected ISender _mediator;

    protected ApiControllerBase(ISender mediator)
    {
        _mediator = mediator;
    }
}
