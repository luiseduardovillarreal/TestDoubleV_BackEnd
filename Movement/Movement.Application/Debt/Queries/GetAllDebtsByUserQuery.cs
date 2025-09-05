using MediatR;
using Movement.Application.Commons;
using Movement.Domain.Contracts;
using System.Net;
using Movement.Application.Deb_t.DTOs.QueryAllByUser;

namespace Movement.Application.Deb_t.Queries;

internal class GetAllDebtsByUserQuery(IUnitOfWork unitOfWork) : IRequestHandler<
    GetAllDebtsByUserRequestDTO, CommonResponse<GetAllDebtsByUserResponseDTO>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<CommonResponse<GetAllDebtsByUserResponseDTO>> Handle(
        GetAllDebtsByUserRequestDTO request, CancellationToken cancellationToken)
    {
        var debts = await _unitOfWork.DebtRepository.FindAllByUserDebtorAsync(
            request.IdUserDebtor);

        if (debts.Count() > 0)
        {
            _unitOfWork.Dispose();
            return new()
            {
                Data = null,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true
            };
        }

        _unitOfWork.Dispose();
        return new()
        {
            Data = new(new()),
            StatusCode = HttpStatusCode.NotFound,
            Message = Constants.Debt.Queries.GetAllDebtsByUserDebtorQuery.NO_LOAD_DATA,
            MessageCustom = Constants.Debt.Queries.GetAllDebtsByUserDebtorQuery.NOT_FOUND_DATA,
            Succeeded = true
        };
    }
}