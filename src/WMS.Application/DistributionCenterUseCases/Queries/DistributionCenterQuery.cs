using MediatR;
using WMS.Application.DistributionCenterUseCases.Responses;

namespace WMS.Application.DistributionCenterUseCases.Queries;

public record DistributionCenterQuery(
    Guid? Id,
    string? InternalCode,
    string? Name,
    string? Document
) : IRequest<IEnumerable<DistributionCenterResponse>>;