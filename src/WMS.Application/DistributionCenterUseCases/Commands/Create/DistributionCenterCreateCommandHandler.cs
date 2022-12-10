using ErrorOr;
using MediatR;
using WMS.Application.DistributionCenterUseCases.Errors;
using WMS.Application.DistributionCenterUseCases.Responses;
using WMS.Application.DistributionCenterUseCases.Services;
using WMS.Domain.DistributionCenter;
using WMS.Persistence.Common.UnitOfWork;
using WMS.Persistence.DistributionCenterPersistence;

namespace WMS.Application.DistributionCenterUseCases.Commands.Create;

public class DistributionCenterCreateCommandHandler : IRequestHandler<DistributionCenterCreateCommand, ErrorOr<DistributionCenterResponse>>
{
    private readonly IDistributionCenterRepository _cdRepositor;
    private readonly IUnitOfWork _unitOfWork;

    public DistributionCenterCreateCommandHandler(IDistributionCenterRepository cdRepositor, IUnitOfWork unitOfWork)
    {
        _cdRepositor = cdRepositor;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<DistributionCenterResponse>> Handle(DistributionCenterCreateCommand request, CancellationToken cancellationToken)
    {
        ErrorOr<DistributionCenter> errorOrDistributionCenter = DistributionCenter.Create(
            request.InternalCode,
            request.Name,
            request.Document
        );

        if (errorOrDistributionCenter.IsError) return errorOrDistributionCenter.Errors;

        DistributionCenter distributionCenter = errorOrDistributionCenter.Value;

        DistributionCenter? documentAlreadyExists = _cdRepositor.GetByDocument(distributionCenter.Document);
        if (documentAlreadyExists is not null) return DistributionCenterErrors.DocumentAlreadyExists;

        DistributionCenter? internalCodeAlreadyExists = _cdRepositor.GetByInternalCode(distributionCenter.InternalCode);
        if (internalCodeAlreadyExists is not null) return DistributionCenterErrors.InternalCodeAlreadyExists;

        _cdRepositor.Create(distributionCenter);

        ErrorOr<int> errorOrCommit = await _unitOfWork.SaveChangesAsync(cancellationToken);
        if (errorOrCommit.IsError) return errorOrCommit.Errors;

        return DistributionCenterFormatResponseService.FormatResponse(errorOrDistributionCenter.Value);
    }
}