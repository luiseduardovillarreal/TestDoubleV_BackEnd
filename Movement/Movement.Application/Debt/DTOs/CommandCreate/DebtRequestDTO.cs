namespace Movement.Application.Deb_t.DTOs.CommandCreate;

public record DebtRequestDTO(Guid IdUserDebtor, Guid IdUserCreditor,
    double Amount, double Difference)
{
    public virtual bool Validations()
        => Amount > 0;
};