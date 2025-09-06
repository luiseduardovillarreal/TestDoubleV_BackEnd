using I_AM.Application.LogIn.DTOs;
using I_AM.Domain.Entities;
using login_UserDTO = I_AM.Application.LogIn.DTOs.UserDTO;
using create_UserDTO = I_AM.Application.Use_r.DTOs.UserDTO;

namespace I_AM.WebAPI.ConfigMap;

public class AutoMapperConfigurations : AutoMapper.Profile
{
    public AutoMapperConfigurations()
    {
        CreateMap<User, create_UserDTO>();        
        CreateMap<User, login_UserDTO>()
            .ForMember(dest => dest.Modules,
                opt => opt.MapFrom(src => src.Users_Profiles
                    .SelectMany(up => up.Profile.Profiles_Modules)
                    .Select(pm => pm.Module)))
            .ForMember(dest => dest.SubModules,
                opt => opt.MapFrom(src => src.Users_Profiles
                    .SelectMany(up => up.Profile.Profiles_SubModules)
                    .Select(psm => psm.SubModule)));
        CreateMap<Module, ModuleDTO>();
        CreateMap<SubModule, SubModuleDTO>();
    }
}