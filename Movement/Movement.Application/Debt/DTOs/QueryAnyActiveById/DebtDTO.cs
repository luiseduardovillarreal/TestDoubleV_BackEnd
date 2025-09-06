namespace Movement.Application.Deb_t.DTOs.QueryAnyActiveById;

public record DebtDTO(Guid Id, UserDTO UserDebtor, 
    UserDTO UserCreditor, double Amount, double Difference, 
    DateTime CreateAt, DateTime? UpdateAt, bool IsActive, 
    ICollection<DebtMovementDTO> DebtsMovements);