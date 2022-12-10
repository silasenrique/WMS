using WMS.Domain.Common.ValueObjects;
using WMS.Domain.DistributionCenter;
using WMS.Domain.DistributionCenter.ValueObjects;
using WMS.Persistence.Common.Repository;

namespace WMS.Persistence.DistributionCenterPersistence;

public interface IDistributionCenterRepository : IGenericRepository<DistributionCenter>
{
    DistributionCenter? GetByDocument(LegalDocument document);
    DistributionCenter? GetByInternalCode(string internalCode);
    DistributionCenter? GetById(DistributionCenterId id);
}