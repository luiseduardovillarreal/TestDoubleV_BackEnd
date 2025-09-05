namespace I_AM.Application.Use_r.DTOs;

#pragma warning disable CS8618

public abstract class UserDTO
{
    public string Identification { get; set; }
    public string Names { get; set; }
    public string LastNames { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
}