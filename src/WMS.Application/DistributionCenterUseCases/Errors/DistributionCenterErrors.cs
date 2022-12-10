using ErrorOr;

namespace WMS.Application.DistributionCenterUseCases.Errors;

public static class DistributionCenterErrors
{
    public static readonly Error DocumentAlreadyExists = Error.Conflict(
        "DocumentAlreadyExists",
        "the document is already being used by another distribution center.");

    public static readonly Error InternalCodeAlreadyExists = Error.Conflict(
        "InternalCodeAlreadyExists",
        "the internal code is already being used by another distribution center");
}