using System.Linq.Expressions;
using WMS.Domain.Common.ValueObjects;
using WMS.Domain.DistributionCenter;
using WMS.Domain.DistributionCenter.ValueObjects;
using WMS.Persistence.Common.Repository;
using WMS.Persistence.Configuration;

namespace WMS.Persistence.DistributionCenterPersistence;

public class DistributionCenterRepository : GenericRepository<DistributionCenter>, IDistributionCenterRepository
{
    public DistributionCenterRepository(ApplicationContext context) : base(context) { }

    public DistributionCenter? GetByDocument(LegalDocument document)
    {
        Expression<Func<DistributionCenter, bool>> expression =
            ex => ex.Document == document;

        return Get(expression)?.FirstOrDefault();
    }

    public DistributionCenter? GetById(DistributionCenterId id)
    {
        Expression<Func<DistributionCenter, bool>> expression =
            ex => ex.Id == id;

        return Get(expression)?.FirstOrDefault();
    }

    public DistributionCenter? GetByInternalCode(string internalCode)
    {
        Expression<Func<DistributionCenter, bool>> expression =
            ex => ex.InternalCode == internalCode;

        return Get(expression)?.FirstOrDefault();
    }
}