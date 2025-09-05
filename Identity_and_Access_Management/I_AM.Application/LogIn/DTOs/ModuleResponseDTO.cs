namespace I_AM.Application.LogIn.DTOs;

#pragma warning disable CS8618

public class ModuleResponseDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public ICollection<SubModuleResponseDTO> SubModules { get; set; } = new List<SubModuleResponseDTO>();
}