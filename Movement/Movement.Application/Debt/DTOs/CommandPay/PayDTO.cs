namespace Movement.Application.Deb_t.DTOs.CommandPay;

public record PayDTO(Guid IdDebt, double Amount)
{
    public virtual bool Validations()
        => Amount > 0;
};