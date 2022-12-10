using ErrorOr;
using MediatR;
using WMS.Application.DistributionCenterUseCases.Responses;

namespace WMS.Application.DistributionCenterUseCases.Commands.Update.DistributionCenterUpdateInternalCode;

public record DistributionCenterUpdateDocumentCommand(
    Guid Id,
    string Document
) : IRequest<ErrorOr<DistributionCenterResponse>>;