using MediatR;
using Movement.Application.Commons;
using Movement.Application.Deb_t.DTOs.QueryAnyById;
using Movement.Domain.Contracts;
using System.Net;

namespace Movement.Application.Deb_t.Queries;

internal class GetAnyDebtByIdQuery(IUnitOfWork unitOfWork) : IRequestHandler<
    GetAnyDebtByIdRequestDTO, CommonResponse<GetAnyDebtByIdResponseDTO>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<CommonResponse<GetAnyDebtByIdResponseDTO>> Handle(
        GetAnyDebtByIdRequestDTO request, CancellationToken cancellationToken)
    {
        var debt = await _unitOfWork.DebtRepository.FindAnyByIdAsync(request.IdDebt);

        if (debt is not null)
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
            Data = null,
            StatusCode = HttpStatusCode.NotFound,
            Message = Constants.Debt.Queries.GetAnyDebtByIdQuery.NO_LOAD_DATA,
            MessageCustom = Constants.Debt.Queries.GetAnyDebtByIdQuery.NOT_FOUND_DATA,
            Succeeded = true
        };
    }
}