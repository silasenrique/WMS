using ErrorOr;
using MediatR;

namespace WMS.Application.DistributionCenterUseCases.Commands.Delete;

public record DistributionCenterDeleteCommand(
    Guid Id
) : IRequest<Error?>;