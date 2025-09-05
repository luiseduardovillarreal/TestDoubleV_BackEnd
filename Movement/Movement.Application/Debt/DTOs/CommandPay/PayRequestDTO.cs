namespace Movement.Application.Deb_t.DTOs.CommandPay;

public record PayRequestDTO(Guid IdDebt, double Amount)
{
    public virtual bool Validations()
        => Amount > 0;
};