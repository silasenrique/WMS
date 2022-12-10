using ErrorOr;
using MediatR;
using WMS.Application.DistributionCenterUseCases.Responses;
using WMS.Application.DistributionCenterUseCases.Services;
using WMS.Domain.Common.ValueObjects;
using WMS.Domain.DistributionCenter;
using WMS.Domain.DistributionCenter.ValueObjects;
using WMS.Persistence.Common.UnitOfWork;
using WMS.Persistence.DistributionCenterPersistence;

namespace WMS.Application.DistributionCenterUseCases.Commands.Update.DistributionCenterUpdateInternalCode;

public class DistributionCenterUpdateDocumentHandler : IRequestHandler<DistributionCenterUpdateDocumentCommand, ErrorOr<DistributionCenterResponse>>
{
    private readonly IDistributionCenterRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DistributionCenterUpdateDocumentHandler(IDistributionCenterRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<DistributionCenterResponse>> Handle(DistributionCenterUpdateDocumentCommand request, CancellationToken cancellationToken)
    {
        ErrorOr<LegalDocument> errorOrDocument = LegalDocument.Create(request.Document);
        if (errorOrDocument.IsError) return errorOrDocument.FirstError;

        DistributionCenter? documentExist = _repository.GetByDocument(errorOrDocument.Value);
        if (documentExist is not null) return Error.Conflict();

        DistributionCenter? oldDistributionCenter = _repository.GetById(DistributionCenterId.ParseId(request.Id));
        if (oldDistributionCenter is null) return Error.NotFound();

        oldDistributionCenter.ChangeDocument(request.Document);

        _repository.Update(oldDistributionCenter);

        ErrorOr<int> errorOrCommit = await _unitOfWork.SaveChangesAsync(cancellationToken);
        if (errorOrCommit.IsError) return errorOrCommit.Errors;

        return DistributionCenterFormatResponseService.FormatResponse(oldDistributionCenter);
    }
}