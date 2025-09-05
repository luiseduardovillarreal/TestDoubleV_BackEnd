namespace Movement.Application.Deb_t.DTOs.QueryAnyActiveById;

public record DebtResponseDTO(Guid Id, UserResponseDTO UserDebtor, 
    UserResponseDTO UserCreditor, double Amount, double Difference, 
    DateTime CreateAt, DateTime? UpdateAt, bool IsActive, 
    ICollection<DebtMovementResponseDTO> DebtsMovements);