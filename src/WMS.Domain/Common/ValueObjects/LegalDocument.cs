using ErrorOr;
using WMS.Domain.Common.Errors;
using WMS.Domain.Common.Models;

namespace WMS.Domain.Common.ValueObjects;

public class LegalDocument : ValueObject
{
    public string Value { get; set; }

    private LegalDocument(string value)
    {
        Value = value;
    }

    public static ErrorOr<LegalDocument> Create(string value)
    {
        return IsValid(value) ?? (ErrorOr<LegalDocument>)new LegalDocument(value);
    }

    private static Error? IsValid(string value)
    {
        if (value.Length != 14) return DocumentErrors.InvalidLegalDocument;

        return null;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}