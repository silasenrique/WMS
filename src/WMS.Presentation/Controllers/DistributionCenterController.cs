using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wms.Core.Presentation.Controllers;
using WMS.Application.DistributionCenterUseCases.Commands.Create;
using WMS.Application.DistributionCenterUseCases.Commands.Delete;
using WMS.Application.DistributionCenterUseCases.Commands.Update.DistributionCenterUpdateInternalCode;
using WMS.Application.DistributionCenterUseCases.Queries;
using WMS.Application.DistributionCenterUseCases.Responses;

namespace WMS.Presentation.Controllers;

[Route("api/distribution-center")]
public class DistributionCenterController : MainController
{
    private readonly ISender _sender;

    public DistributionCenterController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult> Create(DistributionCenterCreateCommand request)
    {
        ErrorOr<DistributionCenterResponse> errorOrResponse = await _sender.Send(request);

        return errorOrResponse.Match(
            response => Ok(response),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] DistributionCenterQuery request)
    {
        IEnumerable<DistributionCenterResponse> response = await _sender.Send(request);

        return Ok(response);
    }

    [HttpPut("/update-document")]
    public async Task<ActionResult> Update(DistributionCenterUpdateDocumentCommand request)
    {
        ErrorOr<DistributionCenterResponse> errorOrResponse = await _sender.Send(request);

        return errorOrResponse.Match(
            response => Ok(response),
            errors => Problem(errors)
        );
    }

    [HttpPut("/update-internal-code")]
    public async Task<ActionResult> Update(DistributionCenterUpdateInternalCodeCommand request)
    {
        ErrorOr<DistributionCenterResponse> errorOrResponse = await _sender.Send(request);

        return errorOrResponse.Match(
            response => Ok(response),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(DistributionCenterDeleteCommand request)
    {
        Error? errorOrResponse = await _sender.Send(request);
        if (errorOrResponse is null) return NoContent();

        return Problem(errorOrResponse.Value);
    }
}