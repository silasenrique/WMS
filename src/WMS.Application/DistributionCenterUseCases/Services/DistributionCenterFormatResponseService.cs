using WMS.Application.DistributionCenterUseCases.Responses;
using WMS.Domain.DistributionCenter;

namespace WMS.Application.DistributionCenterUseCases.Services;

public static class DistributionCenterFormatResponseService
{
    public static DistributionCenterResponse FormatResponse(DistributionCenter distributionCenter)
    {
        return new DistributionCenterResponse(
            distributionCenter.Id.Value.ToString(),
            distributionCenter.InternalCode,
            distributionCenter.Name,
            distributionCenter.Document.Value,
            distributionCenter.DateCreated.ToString(),
            distributionCenter.DateUpdated.ToString()
        );
    }

    public static IEnumerable<DistributionCenterResponse> FormatResponse(IEnumerable<DistributionCenter> distributionCenter)
    {
        return distributionCenter.Select(cd => new DistributionCenterResponse(
            cd.Id.Value.ToString(),
            cd.InternalCode,
            cd.Name,
            cd.Document.Value,
            cd.DateCreated.ToString(),
            cd.DateUpdated.ToString()
        ));
    }
}