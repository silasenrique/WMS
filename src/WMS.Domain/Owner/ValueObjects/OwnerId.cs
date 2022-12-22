using WMS.Domain.Common.Models;

namespace WMS.Domain.Owner.ValueObjects;

public class OwnerId : ValueObject
{
    private OwnerId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static OwnerId CreateUnique()
    {
        return new OwnerId(Guid.NewGuid());
    }

    public static OwnerId ParseId(Guid id)
    {
        return new OwnerId(id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}