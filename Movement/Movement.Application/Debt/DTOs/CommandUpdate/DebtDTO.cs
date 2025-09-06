namespace Movement.Application.Deb_t.DTOs.CommandUpdate;

public record DebtDTO(Guid IdDebt, double Amount)
{
    public virtual bool Validations()
        => Amount > 0;
};