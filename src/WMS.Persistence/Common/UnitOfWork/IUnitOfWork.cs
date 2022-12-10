using ErrorOr;

namespace WMS.Persistence.Common.UnitOfWork;

public interface IUnitOfWork
{
    Task<ErrorOr<int>> SaveChangesAsync(CancellationToken cancellationToken);
}