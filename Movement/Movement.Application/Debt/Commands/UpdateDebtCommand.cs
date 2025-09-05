using AutoMapper;
using MediatR;
using Movement.Application.Commons;
using Movement.Application.Deb_t.DTOs.CommandUpdate;
using Movement.Domain.Contracts;
using Movement.Domain.Entities;
using System.Net;

namespace Movement.Application.Deb_t.Commands;

internal class UpdateDebtCommand(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateDebtRequestDTO, CommonResponse<string>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<CommonResponse<string>> Handle(UpdateDebtRequestDTO request,
        CancellationToken cancellationToken)
    {
        var validations = request.Debt.Validations();
        if (validations)
        {
            Debt debt = await _unitOfWork.DebtRepository.FindFirstOrDefaultAsync(
                deb => deb.Id.Equals(request.Debt.IdDebt));

            if (debt is not null)
            {
                var validateValueOfNewAmount = debt.ValidateNewAmountAboutDifference(
                    request.Debt.Amount);

                if (validateValueOfNewAmount)
                {
                    debt.ProcessNewAmountAndAdjustDifference(request.Debt.Amount);

                    await _unitOfWork.DebtRepository.AddAsync(debt);

                    var resultCommit = await _unitOfWork.Commit(CancellationToken.None);

                    if (resultCommit > 0)
                    {
                        _unitOfWork.Dispose();
                        return new()
                        {
                            Data = string.Empty,
                            StatusCode = HttpStatusCode.Created,
                            Message = Constants.Debt.Commands.UPDATED,
                            MessageCustom = string.Empty,
                            Succeeded = true
                        };
                    }

                    _unitOfWork.Dispose();
                    return new()
                    {
                        Data = string.Empty,
                        StatusCode = HttpStatusCode.InternalServerError,
                        Message = Constants.Debt.Commands.NO_UPDATED,
                        MessageCustom = Constants.CommondResponsesCustom.COMMIT_0,
                        Succeeded = false
                    };
                }

                _unitOfWork.Dispose();
                return new()
                {
                    Data = string.Empty,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = Constants.Debt.Commands.NO_UPDATED,
                    MessageCustom = Constants.Debt.Commands.FAILED_VALIDATIONS_NEW_AMOUNT,
                    Succeeded = false
                };
            }

            _unitOfWork.Dispose();
            return new()
            {
                Data = string.Empty,
                StatusCode = HttpStatusCode.BadRequest,
                Message = Constants.Debt.Commands.NO_UPDATED,
                MessageCustom = Constants.Debt.Commands.DEBT_NOT_EXIST,
                Succeeded = false
            };
        }

        _unitOfWork.Dispose();
        return new()
        {
            Data = string.Empty,
            StatusCode = HttpStatusCode.BadRequest,
            Message = Constants.Debt.Commands.NO_UPDATED,
            MessageCustom = Constants.Debt.Commands.FAILED_VALIDATIONS_AMOUNT,
            Succeeded = false
        };
    }
}