using Movement.Domain.Entities;
using create_DebtRequestDTO = Movement.Application.Deb_t.DTOs.CommandCreate.DebtDTO;
using anyById_DebtResponseDTO = Movement.Application.Deb_t.DTOs.QueryAnyById.DebtDTO;
using allByUser_DebtResponseDTO = Movement.Application.Deb_t.DTOs.QueryAllByUser.DebtDTO;
using all_DebtResponseDTO = Movement.Application.Deb_t.DTOs.QueryAll.DebtDTO;
using anyActiveById_DebtResponseDTO = Movement.Application.Deb_t.DTOs.QueryAnyActiveById.DebtDTO;

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
    }
}