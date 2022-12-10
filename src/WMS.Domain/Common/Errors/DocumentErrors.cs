using ErrorOr;

namespace WMS.Domain.Common.Errors;

public static class DocumentErrors
{
    public readonly static Error InvalidLegalDocument = Error.Validation(
        code: "InvalidLegalDocument",
        description: "the amount placed on the document is not the official size of a valid document."
    );
}