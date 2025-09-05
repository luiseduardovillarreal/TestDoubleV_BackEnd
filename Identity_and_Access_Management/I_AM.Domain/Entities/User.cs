using Microsoft.EntityFrameworkCore;
using I_AM.Domain.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace I_AM.Domain.Entities;

#pragma warning disable CS8618

[Table(Constants.Entities.User.TBL_USER)]
[Index(nameof(Email), IsUnique = true)]
public partial class User
{
    [Key]
    [Column(Constants.Entities.CommonProperties.ID, Order = 1)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_ID)]
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    [Column(Constants.Entities.User.NAMES, Order = 2)]
    [Comment(Constants.Entities.User.COMMENTS_ON_NAMES)]
    public string Names { get; set; }

    [Required]
    [StringLength(100)]
    [Column(Constants.Entities.User.LAST_NAMES, Order = 3)]
    [Comment(Constants.Entities.User.COMMENTS_ON_LAST_NAMES)]
    public string LastNames { get; set; }

    [Required]
    [StringLength(200)]
    [Column(Constants.Entities.User.EMAIL, Order = 4)]
    [Comment(Constants.Entities.User.COMMENTS_ON_EMAIL)]
    public string Email { get; set; }

    [Required]
    [StringLength(500)]
    [Column(Constants.Entities.User.PASSWORD, Order = 5)]
    [Comment(Constants.Entities.User.COMMENTS_ON_PASSWORD)]
    public string Password { get; set; }

    [Column(Constants.Entities.CommonProperties.CREATE_AT, Order = 6)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_CREATE_AT)]
    public DateTime CreateAt { get; set; }

    [Column(Constants.Entities.CommonProperties.UPDATE_AT, Order = 7)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_CREATE_AT)]
    public DateTime? UpdateAt { get; set; }

    [Column(Constants.Entities.CommonProperties.IS_ACTIVE, Order = 8)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_IS_ACTIVE)]
    public bool IsActive { get; set; }

    public virtual ICollection<TokenUser> TokensUsers { get; } = new List<TokenUser>();

    public virtual ICollection<User_Profile> Users_Profiles { get; } = new List<User_Profile>();

    public virtual ICollection<User_Rol> Users_Rols { get; } = new List<User_Rol>();

    public virtual ICollection<Debt> DebtsDebtor { get; } = new List<Debt>();

    public virtual ICollection<Debt> DebtsCreditor { get; } = new List<Debt>();
}