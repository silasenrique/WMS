using WMS.Domain.Common.Models;
using WMS.Domain.Common.ValueObjects;
using WMS.Domain.Owner.ValueObjects;

namespace WMS.Domain.Owner;

public class Owner : Entity<OwnerId>, IAudit
{
    public Owner(OwnerId id) : base(id)
    {
    }

    public string InternalCode { get; }
    public string Name { get; }
    public LegalDocument Document { get; }

    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
}