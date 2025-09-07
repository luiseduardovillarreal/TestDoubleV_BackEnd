using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using I_AM.Domain.Commons;

namespace I_AM.Domain.Entities;

[Table(Constants.Entities.User_Profile.TBL_USER_PROFILE)]
public partial class User_Profile
{
    [Key]
    [Column(Constants.Entities.CommonProperties.ID, Order = 1)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_ID)]
    public Guid Id { get; set; }

    [ForeignKey(Constants.Entities.ForeignsKeys.FOREIGN_KEY_USER)]
    [Column(Constants.Entities.CommonProperties.ID_USER, Order = 2)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_ID_USER)]
    public Guid IdUser { get; set; }

    [ForeignKey(Constants.Entities.ForeignsKeys.FOREIGN_KEY_PROFILE)]
    [Column(Constants.Entities.CommonProperties.ID_PROFILE, Order = 3)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_ID_PROFILE)]
    public Guid IdProfile { get; set; }

    [Column(Constants.Entities.CommonProperties.CREATE_AT, Order = 4)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_CREATE_AT)]
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;

    public virtual User User { get; set; } = null!;

    public virtual Profile Profile { get; set; } = null!;
}