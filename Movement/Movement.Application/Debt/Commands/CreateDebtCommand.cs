using AutoMapper;
using MediatR;
using Movement.Application.Commons;
using Movement.Application.Deb_t.DTOs.CommandCreate;
using Movement.Domain.Contracts;
using Movement.Domain.Entities;
using System.Net;

namespace Movement.Application.Deb_t.Commands;

internal class CreateDebtCommand(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateDebtRequestDTO, CommonResponse<string>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<CommonResponse<string>> Handle(CreateDebtRequestDTO request,
        CancellationToken cancellationToken)
    {
        var validations = request.Debt.Validations();
        if (validations)
        {
            var userDebtor = await _unitOfWork.UserRepository.FindFirstOrDefaultAsync(
                usr => usr.Id.Equals(request.Debt.IdUserDebtor));

            var userCreditor = await _unitOfWork.UserRepository.FindFirstOrDefaultAsync(
                usr => usr.Id.Equals(request.Debt.IdUserCreditor));

            if (userDebtor is not null)
            {
                if (userCreditor is not null)
                {
                    Debt debt = _mapper.Map<Debt>(request.Debt);
                    await _unitOfWork.DebtRepository.AddAsync(debt);

                    var resultCommit = await _unitOfWork.Commit(CancellationToken.None);

                    if (resultCommit > 0)
                    {
                        _unitOfWork.Dispose();
                        return new()
                        {
                            Data = string.Empty,
                            StatusCode = HttpStatusCode.Created,
                            Message = Constants.Debt.Commands.CREATED,
                            MessageCustom = string.Empty,
                            Succeeded = true
                        };
                    }

                    _unitOfWork.Dispose();
                    return new()
                    {
                        Data = string.Empty,
                        StatusCode = HttpStatusCode.InternalServerError,
                        Message = Constants.Debt.Commands.NO_CREATED,
                        MessageCustom = Constants.CommondResponsesCustom.COMMIT_0,
                        Succeeded = false
                    };
                }

                _unitOfWork.Dispose();
                return new()
                {
                    Data = string.Empty,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = Constants.Debt.Commands.NO_CREATED,
                    MessageCustom = Constants.Debt.Commands.CREDITOR_NOT_EXIST,
                    Succeeded = false
                };
            }

            _unitOfWork.Dispose();
            return new()
            {
                Data = string.Empty,
                StatusCode = HttpStatusCode.BadRequest,
                Message = Constants.Debt.Commands.NO_CREATED,
                MessageCustom = Constants.Debt.Commands.DEBTOR_NOT_EXIST,
                Succeeded = false
            };
        }

        _unitOfWork.Dispose();
        return new()
        {
            Data = string.Empty,
            StatusCode = HttpStatusCode.BadRequest,
            Message = Constants.Debt.Commands.NO_CREATED,
            MessageCustom = Constants.Debt.Commands.FAILED_VALIDATIONS_AMOUNT,
            Succeeded = false
        };
    }
}