namespace WMS.Application.DistributionCenterUseCases.Responses;

public record DistributionCenterResponse(
    string Id,
    string InternalCode,
    string Name,
    string Document,
    string CreateDate,
    string LastChangeDate
);