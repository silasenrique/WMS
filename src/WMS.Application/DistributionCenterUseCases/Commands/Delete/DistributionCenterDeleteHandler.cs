using ErrorOr;
using MediatR;
using WMS.Domain.DistributionCenter;
using WMS.Domain.DistributionCenter.ValueObjects;
using WMS.Persistence.Common.UnitOfWork;
using WMS.Persistence.DistributionCenterPersistence;

namespace WMS.Application.DistributionCenterUseCases.Commands.Delete;

public class DistributionCenterDeleteHandler : IRequestHandler<DistributionCenterDeleteCommand, Error?>
{
    private readonly IDistributionCenterRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DistributionCenterDeleteHandler(IDistributionCenterRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Error?> Handle(DistributionCenterDeleteCommand request, CancellationToken cancellationToken)
    {
        DistributionCenter? willBeDeleted = _repository.GetById(DistributionCenterId.ParseId(request.Id));
        if (willBeDeleted is null) return null;

        _repository.Delete(willBeDeleted);

        ErrorOr<int> errorOrCommit = await _unitOfWork.SaveChangesAsync(cancellationToken);
        if (errorOrCommit.IsError) return errorOrCommit.FirstError;

        return null;
    }
}