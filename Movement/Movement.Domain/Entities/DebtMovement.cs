using Microsoft.EntityFrameworkCore;
using Movement.Domain.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movement.Domain.Entities;

[Table(Constants.Entities.DebtMovement.TBL_MOVEMENT_DEBT_MOVEMENT)]
public partial class DebtMovement
{
    [Key]
    [Column(Constants.Entities.CommonProperties.ID, Order = 1)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_ID)]
    public Guid Id { get; set; }

    [ForeignKey(Constants.Entities.ForeignsKeys.FOREIGN_KEY_DEBT)]
    [Column(Constants.Entities.DebtMovement.ID_DEBT, Order = 2)]
    [Comment(Constants.Entities.DebtMovement.COMMENTS_ON_PROPERTIES_ID_DEBT)]
    public Guid IdDebt { get; set; }

    [Required]
    [Column(Constants.Entities.CommonProperties.AMOUNT, Order = 3)]
    [Comment(Constants.Entities.DebtMovement.COMMENTS_ON_AMOUNT)]
    public double Amount { get; set; }

    [Column(Constants.Entities.CommonProperties.CREATE_AT, Order = 4)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_CREATE_AT)]
    public DateTime CreateAt { get; set; } = DateTime.Now;

    public virtual Debt Debt { get; set; } = null!;
}