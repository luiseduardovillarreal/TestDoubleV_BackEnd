using Movement.Domain.Entities;
using create_DebtRequestDTO = Movement.Application.Deb_t.DTOs.CommandCreate.DebtRequestDTO;
using update_DebtRequestDTO = Movement.Application.Deb_t.DTOs.CommandUpdate.DebtRequestDTO;
using anyById_DebtResponseDTO = Movement.Application.Deb_t.DTOs.QueryAnyById.DebtResponseDTO;
using allByUser_DebtResponseDTO = Movement.Application.Deb_t.DTOs.QueryAllByUser.DebtResponseDTO;
using all_DebtResponseDTO = Movement.Application.Deb_t.DTOs.QueryAll.DebtResponseDTO;
using anyActiveById_DebtResponseDTO = Movement.Application.Deb_t.DTOs.QueryAnyActiveById.DebtResponseDTO;

namespace Movement.WebAPI.ConfigMap;

public class AutoMapperConfigurations : AutoMapper.Profile
{
    public AutoMapperConfigurations()
    {
        CreateMap<create_DebtRequestDTO, Debt>();
        CreateMap<Debt, anyById_DebtResponseDTO>();
        CreateMap<Debt, allByUser_DebtResponseDTO>();
        CreateMap<Debt, all_DebtResponseDTO>();
        CreateMap<Debt, anyActiveById_DebtResponseDTO>();
        CreateMap<update_DebtRequestDTO, Debt>();        
    }
}