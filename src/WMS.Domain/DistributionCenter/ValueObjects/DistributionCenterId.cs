using WMS.Domain.Common.Models;

namespace WMS.Domain.DistributionCenter.ValueObjects;

public sealed class DistributionCenterId : ValueObject
{
    private DistributionCenterId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static DistributionCenterId CreateUnique()
    {
        return new DistributionCenterId(Guid.NewGuid());
    }

    public static DistributionCenterId ParseId(Guid id)
    {
        return new DistributionCenterId(id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}