namespace I_AM.Application.LogIn.DTOs;

#pragma warning disable CS8618

public class UserResponseDTO
{
    public Guid Id { get; set; }
    public string Names { get; set; }
    public string LastNames { get; set; }
    public string Email { get; set; }
    public ICollection<RolResponseDTO> Rols { get; set; } = new List<RolResponseDTO>();
    public ICollection<ModuleResponseDTO> Modules { get; set; } = new List<ModuleResponseDTO>();
}