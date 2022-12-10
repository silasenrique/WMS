using ErrorOr;
using WMS.Domain.Common.Models;
using WMS.Domain.Common.ValueObjects;
using WMS.Domain.DistributionCenter.Errors;
using WMS.Domain.DistributionCenter.ValueObjects;

namespace WMS.Domain.DistributionCenter;

public class DistributionCenter : Entity<DistributionCenterId>, IAudit
{
    private DistributionCenter(DistributionCenterId id, string internalCode, string name, LegalDocument document) : base(id)
    {
        InternalCode = internalCode;
        Name = name;
        Document = document;
    }

    public string InternalCode { get; private set; }
    public string Name { get; }
    public LegalDocument Document { get; private set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }

    public static ErrorOr<DistributionCenter> Create(string internalCode, string name, string document)
    {
        ErrorOr<bool> errorOrInternalCodeValid = InternalCodeIsValid(internalCode);
        if (errorOrInternalCodeValid.IsError) return errorOrInternalCodeValid.Errors;

        ErrorOr<LegalDocument> errorOrDocument = LegalDocument.Create(document);
        if (errorOrDocument.IsError) return errorOrDocument.Errors;

        return new DistributionCenter(
            DistributionCenterId.CreateUnique(),
            internalCode.ToUpper(),
            name,
            errorOrDocument.Value
        );
    }

    private static ErrorOr<bool> InternalCodeIsValid(string internalCode)
    {
        if (internalCode.Length < 3) return DistributionCenterErrors.VerySmallInternalCode;
        if (internalCode.Length > 6) return DistributionCenterErrors.InternalCodeTooBig;

        return true;
    }

    public void ChangeInternalCode(string newInternalCode)
    {
        InternalCode = newInternalCode.ToUpper();
    }

    public Error? ChangeDocument(string document)
    {
        ErrorOr<LegalDocument> errorOrDocument = LegalDocument.Create(document);
        if (errorOrDocument.IsError) return errorOrDocument.FirstError;

        Document = errorOrDocument.Value;

        return null;
    }
}