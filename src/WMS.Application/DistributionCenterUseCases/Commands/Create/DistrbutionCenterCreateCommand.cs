using ErrorOr;
using MediatR;
using WMS.Application.DistributionCenterUseCases.Responses;

namespace WMS.Application.DistributionCenterUseCases.Commands.Create;

public record DistributionCenterCreateCommand(
    string InternalCode,
    string Name,
    string Document) : IRequest<ErrorOr<DistributionCenterResponse>>;