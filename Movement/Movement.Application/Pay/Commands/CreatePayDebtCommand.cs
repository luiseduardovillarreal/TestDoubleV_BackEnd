using MediatR;
using Movement.Application.Commons;
using Movement.Application.Pa_y.DTOs.CommandPay;
using Movement.Domain.Contracts;
using Movement.Domain.Entities;
using System.Net;

namespace Movement.Application.Pa_y.Commands;

internal class CreatePayDebtCommand(IUnitOfWork unitOfWork)
    : IRequestHandler<CreatePayDebtRequestDTO, CommonResponse<string>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<CommonResponse<string>> Handle(CreatePayDebtRequestDTO request,
        CancellationToken cancellationToken)
    {
        Debt debt = await _unitOfWork.DebtRepository.FindFirstOrDefaultAsync(
            deb => deb.Id.Equals(request.Pay.IdDebt));
        if (debt is not null)
        {
            var validDifferent = debt.ValidPayFromDifference(request.Pay.Amount);
            if (validDifferent)
            {
                debt.AddPay(request.Pay.Amount);
                _unitOfWork.DebtRepository.Update(debt);
                var resultCommit = await _unitOfWork.Commit(CancellationToken.None);
                if (resultCommit > 0)
                {
                    _unitOfWork.Dispose();
                    return new()
                    {
                        Data = string.Empty,
                        StatusCode = HttpStatusCode.Created,
                        Message = Constants.Pay.Commands.PAY,
                        MessageCustom = string.Empty,
                        Succeeded = true
                    };
                }

                _unitOfWork.Dispose();
                return new()
                {
                    Data = string.Empty,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = Constants.Pay.Commands.NO_PAY,
                    MessageCustom = Constants.CommondResponsesCustom.COMMIT_0,
                    Succeeded = false
                };
            }

            _unitOfWork.Dispose();
            return new()
            {
                Data = string.Empty,
                StatusCode = HttpStatusCode.InternalServerError,
                Message = Constants.Pay.Commands.NO_PAY_OUTSIDE,
                MessageCustom = Constants.Pay.Commands.NO_PAY_OUTSIDE,
                Succeeded = false
            };
        }

        _unitOfWork.Dispose();
        return new()
        {
            Data = string.Empty,
            StatusCode = HttpStatusCode.BadRequest,
            Message = Constants.Pay.Commands.NO_PAY,
            MessageCustom = Constants.Debt.Commands.DEBT_NOT_EXIST,
            Succeeded = false
        };
    }
}