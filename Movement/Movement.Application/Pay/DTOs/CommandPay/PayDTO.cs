namespace Movement.Application.Pa_y.DTOs.CommandPay;

public record PayDTO(Guid IdDebt, double Amount)
{
    public virtual bool Validations()
        => Amount > 0;
};