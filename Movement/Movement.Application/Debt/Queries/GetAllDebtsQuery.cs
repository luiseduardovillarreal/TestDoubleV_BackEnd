using MediatR;
using Movement.Application.Commons;
using Movement.Domain.Contracts;
using System.Net;
using Movement.Application.Deb_t.DTOs.QueryAll;

namespace Movement.Application.Deb_t.Queries;

internal class GetAllDebtsQuery(IUnitOfWork unitOfWork)
    : IRequestHandler<GetAllDebtsRequestDTO, CommonResponse<GetAllDebtsResponseDTO>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<CommonResponse<GetAllDebtsResponseDTO>> Handle(
        GetAllDebtsRequestDTO request, CancellationToken cancellationToken)
    {
        var debts = await _unitOfWork.DebtRepository.FindAllAsync();

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
            Message = Constants.Debt.Queries.GetAllDebtsQuery.NO_LOAD_DATA,
            MessageCustom = Constants.Debt.Queries.GetAllDebtsQuery.NOT_FOUND_DATA,
            Succeeded = true
        };
    }
}