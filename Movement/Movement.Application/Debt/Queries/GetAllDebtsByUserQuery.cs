using AutoMapper;
using MediatR;
using Movement.Application.Commons;
using Movement.Application.Deb_t.DTOs.QueryAllByUser;
using Movement.Domain.Contracts;
using System.Net;

namespace Movement.Application.Deb_t.Queries;

internal class GetAllDebtsByUserQuery(IUnitOfWork unitOfWork, IMapper mapper) 
    : IRequestHandler<
        GetAllDebtsByUserRequestDTO, 
        CommonResponse<GetAllDebtsByUserResponseDTO>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<CommonResponse<GetAllDebtsByUserResponseDTO>> Handle(
        GetAllDebtsByUserRequestDTO request, CancellationToken cancellationToken)
    {
        var debts = await _unitOfWork.DebtRepository.FindAllByUserDebtorAsync(
            request.IdDebtor);

        if (debts.Count() > 0)
        {
            var debtsDTO = _mapper.Map<List<DebtDTO>>(debts);

            _unitOfWork.Dispose();
            return new()
            {
                Data = new(debtsDTO),
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