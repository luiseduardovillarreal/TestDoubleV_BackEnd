namespace I_AM.Application.LogIn.DTOs;

#pragma warning disable CS8618

public class ModuleDTO 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public List<SubModuleDTO> SubModules { get; set; } = new();
}