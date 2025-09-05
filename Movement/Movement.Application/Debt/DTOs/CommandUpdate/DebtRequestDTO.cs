namespace Movement.Application.Deb_t.DTOs.CommandUpdate;

public record DebtRequestDTO(Guid IdDebt, double Amount)
{
    public virtual bool Validations()
        => Amount > 0;
};