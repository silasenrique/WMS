using ErrorOr;
using MediatR;
using WMS.Application.DistributionCenterUseCases.Responses;

namespace WMS.Application.DistributionCenterUseCases.Commands.Update.DistributionCenterUpdateInternalCode;

public record DistributionCenterUpdateInternalCodeCommand(
    Guid Id,
    string InternalCode
) : IRequest<ErrorOr<DistributionCenterResponse>>;