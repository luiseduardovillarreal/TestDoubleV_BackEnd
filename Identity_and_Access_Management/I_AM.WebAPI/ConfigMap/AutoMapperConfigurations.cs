using I_AM.Application.LogIn.DTOs;
using I_AM.Domain.Entities;
using create_UserDTO = I_AM.Application.Use_r.DTOs.CommandCreate.UserDTO;
using getAll_UserDTO = I_AM.Application.Use_r.DTOs.QueryAll.UserDTO;
using login_UserDTO = I_AM.Application.LogIn.DTOs.UserDTO;

namespace I_AM.WebAPI.ConfigMap;

public class AutoMapperConfigurations : AutoMapper.Profile
{
    public AutoMapperConfigurations()
    {
        CreateMap<create_UserDTO, User>();
        CreateMap<User, getAll_UserDTO>();
        CreateMap<User, login_UserDTO>()
            .ForMember(dest => dest.Modules,
                opt => opt.MapFrom(src =>
                    src.Users_Profiles
                        .SelectMany(up => up.Profile.Profiles_Modules)
                        .Select(pm => new ModuleDTO
                        {
                            Id = pm.Module.Id,
                            Name = pm.Module.Name,
                            Description = pm.Module.Description,
                            Icon = pm.Module.Icon,
                            SubModules = pm.Module.Name == "Dashboard"
                                ? new()
                                : pm.Profile.Profiles_SubModules
                                    .Select(psm => new SubModuleDTO
                                    {
                                        Id = psm.SubModule.Id,
                                        Name = psm.SubModule.Name,
                                        Description = psm.SubModule.Description,
                                        RouterLink = psm.SubModule.RouterLink
                                    }).ToList()
                        })
                        .DistinctBy(m => m.Id)
                ));
    }
}