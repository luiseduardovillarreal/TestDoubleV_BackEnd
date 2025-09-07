using MediatR;
using Movement.Application.Commons;
using Movement.Application.Deb_t.DTOs.CommandActivate;
using Movement.Domain.Contracts;
using Movement.Domain.Entities;
using System.Net;

namespace Movement.Application.Deb_t.Commands;

internal class ActivateDebtCommand(IUnitOfWork unitOfWork)
    : IRequestHandler<ActivateDebtRequestDTO, CommonResponse<string>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<CommonResponse<string>> Handle(ActivateDebtRequestDTO request,
        CancellationToken cancellationToken)
    {
        Debt debt = await _unitOfWork.DebtRepository.FindFirstOrDefaultAsync(
            deb => deb.Id.Equals(request.Id));

        if (debt is not null)
        {
            if (debt.IsActive is false)
            {                
                debt.Activate();

                _unitOfWork.DebtRepository.Update(debt);

                var resultCommit = await _unitOfWork.Commit(CancellationToken.None);
                if (resultCommit > 0)
                {
                    _unitOfWork.Dispose();
                    return new()
                    {
                        Data = string.Empty,
                        StatusCode = HttpStatusCode.OK,
                        Message = Constants.Debt.Commands.ACTIVATED,
                        MessageCustom = string.Empty,
                        Succeeded = true
                    };
                }

                _unitOfWork.Dispose();
                return new()
                {
                    Data = string.Empty,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = Constants.Debt.Commands.NO_ACTIVATED,
                    MessageCustom = Constants.CommondResponsesCustom.COMMIT_0,
                    Succeeded = false
                };
            }

            _unitOfWork.Dispose();
            return new()
            {
                Data = string.Empty,
                StatusCode = HttpStatusCode.BadRequest,
                Message = Constants.Debt.Commands.NO_ACTIVATED,
                MessageCustom = Constants.Debt.Commands.DEBT_ACTIVE,
                Succeeded = false
            };
        }

        _unitOfWork.Dispose();
        return new()
        {
            Data = string.Empty,
            StatusCode = HttpStatusCode.BadRequest,
            Message = Constants.Debt.Commands.NO_ACTIVATED,
            MessageCustom = Constants.CommondResponsesCustom.DEBT_NO_EXIST,
            Succeeded = false
        };
    }
}