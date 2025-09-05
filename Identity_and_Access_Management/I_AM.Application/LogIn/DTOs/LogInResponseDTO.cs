using I_AM.Application.Commons;
using I_AM.Application.LogIn.Results;

namespace I_AM.Application.LogIn.DTOs;

#pragma warning disable CS8601

public class LogInResponseDTO(DTOQuerie<LogInResponseResult> resultUserAccessDetai,
    string token)
{
    public UserResponseDTO User { get; set; } = new();
    public string Token { get; set; } = token;

    internal void ProcessDataGetUserAccessDetails()
    {
        User = resultUserAccessDetai.Result.Data
            .GroupBy(u => new { u.IdUser, u.NamesUser, u.LastNamesUser, u.EmailUser })
            .Select(userGroup => new UserResponseDTO
            {
                Id = userGroup.Key.IdUser,
                Names = userGroup.Key.NamesUser,
                LastNames = userGroup.Key.LastNamesUser,
                Email = userGroup.Key.EmailUser,

                Rols = userGroup
                    .Where(r => r.CodeRol != 0 && !string.IsNullOrEmpty(r.NameRol))
                    .Select(r => new RolResponseDTO
                    {
                        Code = r.CodeRol,
                        Name = r.NameRol,
                        Description = r.DescriptionRol
                    })
                    .Distinct()
                    .ToList(),

                Modules = userGroup
                    .Where(m => !string.IsNullOrEmpty(m.NameModule))
                    .GroupBy(m => new { m.NameModule, m.DescriptionModule, m.IconModule })
                    .Select(moduleGroup => new ModuleResponseDTO
                    {
                        Name = moduleGroup.Key.NameModule,
                        Description = moduleGroup.Key.DescriptionModule,
                        Icon = moduleGroup.Key.IconModule,

                        SubModules = moduleGroup
                            .Where(sub => !string.IsNullOrEmpty(sub.NameSubmodule))
                            .Select(sub => new SubModuleResponseDTO
                            {
                                Name = sub.NameSubmodule,
                                Description = sub.DescriptionSubmodule,
                                RouterLink = sub.RouterLinkSubmodule
                            })
                            .Distinct()
                            .ToList()
                    })
                    .ToList()
            })
            .FirstOrDefault();
    }
}