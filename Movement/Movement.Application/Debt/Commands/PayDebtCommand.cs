using MediatR;
using Movement.Application.Commons;
using Movement.Application.Deb_t.DTOs.CommandPay;
using Movement.Domain.Contracts;
using Movement.Domain.Entities;
using System.Net;

namespace Movement.Application.Deb_t.Commands;

internal class PayDebtCommand(IUnitOfWork unitOfWork)
    : IRequestHandler<PayDebtRequestDTO, CommonResponse<string>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<CommonResponse<string>> Handle(PayDebtRequestDTO request,
        CancellationToken cancellationToken)
    {
        Debt debt = await _unitOfWork.DebtRepository.FindFirstOrDefaultAsync(
            deb => deb.Id.Equals(request.Pay.IdDebt));

        if (debt is not null)
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
                    Message = Constants.Debt.Commands.PAY,
                    MessageCustom = string.Empty,
                    Succeeded = true
                };
            }

            _unitOfWork.Dispose();
            return new()
            {
                Data = string.Empty,
                StatusCode = HttpStatusCode.InternalServerError,
                Message = Constants.Debt.Commands.NO_PAY,
                MessageCustom = Constants.CommondResponsesCustom.COMMIT_0,
                Succeeded = false
            };            
        }

        _unitOfWork.Dispose();
        return new()
        {
            Data = string.Empty,
            StatusCode = HttpStatusCode.BadRequest,
            Message = Constants.Debt.Commands.NO_PAY,
            MessageCustom = Constants.Debt.Commands.DEBT_NOT_EXIST,
            Succeeded = false
        };
    }
}