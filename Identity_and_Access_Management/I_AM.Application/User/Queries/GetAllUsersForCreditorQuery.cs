using AutoMapper;
using I_AM.Application.Commons;
using I_AM.Application.Use_r.DTOs.QueryAllForCreditor;
using I_AM.Domain.Contracts;
using MediatR;
using System.Net;

namespace I_AM.Application.Use_r.Queries;

internal class GetAllUsersForCreditorQuery(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<
        GetAllUsersForCreditorRequestDTO, 
        CommonResponse<GetAllUsersForCreditorResponseDTO>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<CommonResponse<GetAllUsersForCreditorResponseDTO>> Handle(
        GetAllUsersForCreditorRequestDTO request, CancellationToken cancellationToken)
    {
        var users = await _unitOfWork.UserRepository.FindAllForCreditorAsync(
            request.IdDebtor);
        if (users.Count() > 0)
        {
            var usersDTO = _mapper.Map<List<UserDTO>>(users);

            _unitOfWork.Dispose();
            return new()
            {
                Data = new(usersDTO),
                StatusCode = HttpStatusCode.OK,
                Succeeded = true
            };
        }

        _unitOfWork.Dispose();
        return new()
        {
            Data = new(new()),
            StatusCode = HttpStatusCode.NotFound,
            Message = Constants.User.Queries.GetAllQuery.NO_LOAD_DATA,
            MessageCustom = Constants.User.Queries.GetAllQuery.NOT_FOUND_DATA,
            Succeeded = true
        };
    }
}