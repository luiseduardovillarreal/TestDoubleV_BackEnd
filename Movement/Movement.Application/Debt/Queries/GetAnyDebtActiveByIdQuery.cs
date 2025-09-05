//using MediatR;
//using Movement.Application.Commons;
//using Movement.Application.Deb_t.DTOs.QueryValidateIsActive;
//using Movement.Domain.Contracts;
//using Movement.Domain.Entities;
//using System.Net;

//namespace Movement.Application.Deb_t.Queries;

//internal class GetAnyDebtActiveByIdQuery(IUnitOfWork unitOfWork) 
//    : IRequestHandler<ValidateIsActiveInquestRequestDTO, CommonResponse<bool>> 
//{
//    private readonly IUnitOfWork _unitOfWork = unitOfWork;

//    public async Task<CommonResponse<bool>> Handle(
//        ValidateIsActiveInquestRequestDTO request, CancellationToken cancellationToken)
//    {
//        Inquest inquest = await _unitOfWork.InquestRepository.FindFirstOrDefaultAsync(
//            inq => inq.Id.Equals(request.IdInquest));

//        if (inquest is not null)
//        {
//            if (inquest.IsActive is true)
//            {
//                _unitOfWork.Dispose();
//                return new()
//                {
//                    Data = true,
//                    StatusCode = HttpStatusCode.OK,
//                    Message = string.Empty,
//                    MessageCustom = string.Empty,
//                    Succeeded = true
//                };
//            }

//            _unitOfWork.Dispose();
//            return new()
//            {
//                Data = false,
//                StatusCode = HttpStatusCode.OK,
//                Message = string.Empty,
//                MessageCustom = string.Empty,
//                Succeeded = true
//            };
//        }

//        _unitOfWork.Dispose();
//        return new()
//        {
//            Data = false,
//            StatusCode = HttpStatusCode.BadRequest,
//            Message = Constants.Inquest.Queries.ValidateIsActiveInquestQuery.NO_FOUND_INQUEST,
//            MessageCustom = 
//                Constants.CommondResponsesCustom.INQUEST_NO_EXIST,
//            Succeeded = false
//        };
//    }
//}