using System.Linq.Expressions;
using MediatR;
using WMS.Application.DistributionCenterUseCases.Responses;
using WMS.Application.DistributionCenterUseCases.Services;
using WMS.Domain.DistributionCenter;
using WMS.Domain.DistributionCenter.ValueObjects;
using WMS.Persistence.DistributionCenterPersistence;

namespace WMS.Application.DistributionCenterUseCases.Queries;

public class DistributionCenterQueryHandler : IRequestHandler<DistributionCenterQuery, IEnumerable<DistributionCenterResponse>>
{
    private readonly IDistributionCenterRepository _repository;

    public DistributionCenterQueryHandler(IDistributionCenterRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DistributionCenterResponse>> Handle(DistributionCenterQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        Expression<Func<DistributionCenter, bool>> expression = e =>
            (e.InternalCode.Contains(request.InternalCode) || request.InternalCode == null) &&
            (e.Name.Contains(request.Name) || request.Name == null) &&
            (e.Id == DistributionCenterId.ParseId(request.Id ?? Guid.Empty) || request.Id == null);

        IEnumerable<DistributionCenter>? distributionsCenter = _repository.Get(expression);
        if (distributionsCenter is null) return new List<DistributionCenterResponse>();

        return DistributionCenterFormatResponseService.FormatResponse(distributionsCenter);
    }
}