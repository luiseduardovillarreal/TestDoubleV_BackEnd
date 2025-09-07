using MediatR;
using Movement.Application.Commons;
using Movement.Application.Deb_t.DTOs.CommandDelete;
using Movement.Domain.Contracts;
using Movement.Domain.Entities;
using System.Net;

namespace Movement.Application.Deb_t.Commands;

internal class DeleteDebtCommand(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteDebtRequestDTO, CommonResponse<string>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<CommonResponse<string>> Handle(DeleteDebtRequestDTO request,
        CancellationToken cancellationToken)
    {
        Debt debt = await _unitOfWork.DebtRepository.FindFirstOrDefaultAsync(
            deb => deb.Id.Equals(request.IdDebt));

        if (debt is not null)
        {
            if (debt.IsActive is true)
            {
                var validateDebt = debt.ValidDifference();
                if (validateDebt)
                {
                    debt.Inactivate();

                    _unitOfWork.DebtRepository.Delete(debt);

                    var resultCommit = await _unitOfWork.Commit(CancellationToken.None);
                    if (resultCommit > 0)
                    {
                        _unitOfWork.Dispose();
                        return new()
                        {
                            Data = string.Empty,
                            StatusCode = HttpStatusCode.OK,
                            Message = Constants.Debt.Commands.DELETED,
                            MessageCustom = string.Empty,
                            Succeeded = true
                        };
                    }

                    _unitOfWork.Dispose();
                    return new()
                    {
                        Data = string.Empty,
                        StatusCode = HttpStatusCode.InternalServerError,
                        Message = Constants.Debt.Commands.NO_DELETED,
                        MessageCustom = Constants.CommondResponsesCustom.COMMIT_0,
                        Succeeded = false
                    };
                }

                _unitOfWork.Dispose();
                return new()
                {
                    Data = string.Empty,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = Constants.Debt.Commands.NO_DELETED_DIFFERENCE,
                    MessageCustom = Constants.Debt.Commands.NO_DELETED_DIFFERENCE,
                    Succeeded = false
                };
            }

            _unitOfWork.Dispose();
            return new()
            {
                Data = string.Empty,
                StatusCode = HttpStatusCode.BadRequest,
                Message = Constants.Debt.Commands.NO_DELETED,
                MessageCustom = Constants.Debt.Commands.DEBT_INACTIVE,
                Succeeded = false
            };
        }

        _unitOfWork.Dispose();
        return new()
        {
            Data = string.Empty,
            StatusCode = HttpStatusCode.BadRequest,
            Message = Constants.Debt.Commands.NO_DELETED,
            MessageCustom = Constants.CommondResponsesCustom.DEBT_NO_EXIST,
            Succeeded = false
        };
    }
}