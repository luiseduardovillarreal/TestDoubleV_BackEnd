using Microsoft.EntityFrameworkCore;
using Movement.Domain.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movement.Domain.Entities;

#pragma warning disable CS8618

[Table(Constants.Entities.TokenUser.TBL_TOKEN_USER)]
[Index(nameof(Token), IsUnique = true)]
public partial class TokenUser
{
    [Key]
    [Column(Constants.Entities.CommonProperties.ID, Order = 1)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_ID)]
    public Guid Id { get; set; }

    [ForeignKey(Constants.Entities.ForeignsKeys.FOREIGN_KEY_USER)]
    [Column(Constants.Entities.CommonProperties.ID_USER, Order = 2)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_ID_USER)]
    public Guid IdUser { get; set; }

    [Required]
    [StringLength(250)]
    [Column(Constants.Entities.TokenUser.TOKEN, Order = 3)]
    [Comment(Constants.Entities.TokenUser.COMMENTS_ON_TOKEN)]
    public string Token { get; set; }

    [Column(Constants.Entities.CommonProperties.CREATE_AT, Order = 4)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_CREATE_AT)]
    public DateTime CreateAt { get; set; }

    [Column(Constants.Entities.TokenUser.EXPIRE_AT, Order = 5)]
    [Comment(Constants.Entities.TokenUser.COMMENTS_ON_EXPIRE_AT)]
    public DateTime ExpireAt { get; set; }

    public virtual User User { get; set; } = null!;
}