using Movement.Domain.Entities;
using create_DebtDTO = Movement.Application.Deb_t.DTOs.CommandCreate.DebtDTO;
using anyById_DebtDTO = Movement.Application.Deb_t.DTOs.QueryAnyById.DebtDTO;
using allByUser_DebtDTO = Movement.Application.Deb_t.DTOs.QueryAllByUser.DebtDTO;
using allByUser_UserDTO = Movement.Application.Deb_t.DTOs.QueryAllByUser.UserDTO;
using allByUser_DebtMovementDTO = Movement.Application.Deb_t.DTOs.QueryAllByUser.DebtMovementDTO;
using anyActiveById_DebtDTO = Movement.Application.Deb_t.DTOs.QueryAnyActiveById.DebtDTO;
using all_DebtDTO = Movement.Application.Deb_t.DTOs.QueryAll.DebtDTO;
using all_UserDTO = Movement.Application.Deb_t.DTOs.QueryAll.UserDTO;
using all_DebtMovementDTO = Movement.Application.Deb_t.DTOs.QueryAll.DebtMovementDTO;

namespace Movement.WebAPI.ConfigMap;

public class AutoMapperConfigurations : AutoMapper.Profile
{
    public AutoMapperConfigurations()
    {
        CreateMap<create_DebtDTO, Debt>();
        CreateMap<Debt, anyById_DebtDTO>();
        CreateMap<User, allByUser_UserDTO>();
        CreateMap<DebtMovement, allByUser_DebtMovementDTO>();
        CreateMap<Debt, allByUser_DebtDTO>()
            .ForMember(
                dest => dest.UserCreditor, 
                opt => opt.MapFrom(src => src.UserCreditor))
            .ForMember(
                dest => dest.DebtsMovements, 
                opt => opt.MapFrom(src => src.DebtsMovements));
        CreateMap<User, all_UserDTO>();
        CreateMap<DebtMovement, all_DebtMovementDTO>();
        CreateMap<Debt, all_DebtDTO>()
            .ForMember(
                dest => dest.UserCreditor,
                opt => opt.MapFrom(src => src.UserCreditor))
            .ForMember(
                dest => dest.DebtsMovements,
                opt => opt.MapFrom(src => src.DebtsMovements));
        CreateMap<Debt, anyActiveById_DebtDTO>();
    }
}