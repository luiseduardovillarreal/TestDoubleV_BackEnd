namespace I_AM.Application.Use_r.DTOs.QueryAll;

public record class UserDTO(Guid Id, string Names, 
    string LastNames, string Email, DateTime CreateAt, 
    DateTime? UpdateAt, bool IsActive);