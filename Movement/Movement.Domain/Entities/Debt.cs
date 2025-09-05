using Microsoft.EntityFrameworkCore;
using Movement.Domain.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movement.Domain.Entities;

[Table(Constants.Entities.Debt.TBL_MOVEMENT_DEBT)]
public partial class Debt
{
    [Key]
    [Column(Constants.Entities.CommonProperties.ID, Order = 1)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_ID)]
    public Guid Id { get; set; }

    [ForeignKey(Constants.Entities.ForeignsKeys.FOREIGN_KEY_USER_DEBTOR)]
    [Column(Constants.Entities.CommonProperties.ID_USER_DEBTOR, Order = 2)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_ID_USER)]
    public Guid IdUserDebtor { get; set; }

    [ForeignKey(Constants.Entities.ForeignsKeys.FOREIGN_KEY_USER_CREDITOR)]
    [Column(Constants.Entities.CommonProperties.ID_USER_CREDITOR, Order = 3)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_ID_USER)]
    public Guid IdUserCreditor { get; set; }

    [Required]
    [Column(Constants.Entities.CommonProperties.AMOUNT, Order = 4)]
    [Comment(Constants.Entities.Debt.COMMENTS_ON_AMOUNT)]
    public double Amount { get; set; }

    [Required]
    [Column(Constants.Entities.Debt.DIFFERENCE, Order = 5)]
    [Comment(Constants.Entities.Debt.COMMENTS_ON_DIFFERENCE)]
    public double Difference { get; set; }

    [Column(Constants.Entities.CommonProperties.CREATE_AT, Order = 6)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_CREATE_AT)]
    public DateTime CreateAt { get; set; }

    [Column(Constants.Entities.CommonProperties.UPDATE_AT, Order = 7)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_UPDATE_AT)]
    public DateTime? UpdateAt { get; set; }

    [Column(Constants.Entities.CommonProperties.IS_ACTIVE, Order = 8)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_IS_ACTIVE)]
    public bool IsActive { get; set; }

    public virtual User UserDebtor { get; set; } = null!;

    public virtual User UserCreditor { get; set; } = null!;

    public virtual ICollection<DebtMovement> DebtsMovements { get; } 
        = new List<DebtMovement>();
}