using ErrorOr;
using MediatR;
using WMS.Application.DistributionCenterUseCases.Responses;
using WMS.Application.DistributionCenterUseCases.Services;
using WMS.Domain.DistributionCenter;
using WMS.Domain.DistributionCenter.ValueObjects;
using WMS.Persistence.Common.UnitOfWork;
using WMS.Persistence.DistributionCenterPersistence;

namespace WMS.Application.DistributionCenterUseCases.Commands.Update.DistributionCenterUpdateInternalCode;

public class DistributionCenterUpdateInternalCodeHandler : IRequestHandler<DistributionCenterUpdateInternalCodeCommand, ErrorOr<DistributionCenterResponse>>
{
    private readonly IDistributionCenterRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DistributionCenterUpdateInternalCodeHandler(IDistributionCenterRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<DistributionCenterResponse>> Handle(DistributionCenterUpdateInternalCodeCommand request, CancellationToken cancellationToken)
    {
        DistributionCenter? internalCodeExist = _repository.GetByInternalCode(request.InternalCode.ToUpper());
        if (internalCodeExist is not null) return Error.Conflict();

        DistributionCenter? oldDistributionCenter = _repository.GetById(DistributionCenterId.ParseId(request.Id));
        if (oldDistributionCenter is null) return Error.NotFound();

        oldDistributionCenter.ChangeInternalCode(request.InternalCode);

        _repository.Update(oldDistributionCenter);

        ErrorOr<int> errorOrCommit = await _unitOfWork.SaveChangesAsync(cancellationToken);
        if (errorOrCommit.IsError) return errorOrCommit.Errors;

        return DistributionCenterFormatResponseService.FormatResponse(oldDistributionCenter);
    }
}