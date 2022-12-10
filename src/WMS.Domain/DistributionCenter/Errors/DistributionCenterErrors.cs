using ErrorOr;

namespace WMS.Domain.DistributionCenter.Errors;

public static class DistributionCenterErrors
{
    public readonly static Error VerySmallInternalCode = Error.Validation(
        code: "VerySmallInternalCode",
        description: "The InternalCode must have at least 3 characters."
    );

    public readonly static Error InternalCodeTooBig = Error.Validation(
        code: "InternalCodeTooBig",
        description: "The InternalCode can only be up to 6 characters long, more than that is not allowed."
    );
}