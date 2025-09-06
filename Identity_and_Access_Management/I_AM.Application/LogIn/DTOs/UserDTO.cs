namespace I_AM.Application.LogIn.DTOs;

#pragma warning disable CS8618

public class UserDTO 
{
    public Guid Id { get; set; }
    public string Names { get; set; }
    public string LastNames { get; set; }
    public string Email { get; set; }
    public List<ModuleDTO> Modules { get; set; } = new();
}