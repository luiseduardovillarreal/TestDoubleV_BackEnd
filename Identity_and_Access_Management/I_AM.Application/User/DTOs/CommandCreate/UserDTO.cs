using System.ComponentModel.DataAnnotations;

namespace I_AM.Application.Use_r.DTOs.CommandCreate;

#pragma warning disable CS8618

public class UserDTO
{
    public string Names { get; set; }
    public string LastNames { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public virtual bool ValidDataInProperties()
        => Names != null && Names != string.Empty &&
           LastNames != null && LastNames != string.Empty &&
           Email != null && Email != string.Empty &&
           Password != null && Password != string.Empty;

    public virtual bool ValidEmil()
        => new EmailAddressAttribute().IsValid(Email);
}