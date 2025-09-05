using Microsoft.EntityFrameworkCore;
using I_AM.Domain.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace I_AM.Domain.Entities;

[Table(Constants.Entities.Profile_Module.TBL_PROFILE_MODULE)]
public partial class Profile_Module
{
    [Key]
    [Column(Constants.Entities.CommonProperties.ID, Order = 1)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_ID)]
    public Guid Id { get; set; }

    [ForeignKey(Constants.Entities.ForeignsKeys.FOREIGN_KEY_PROFILE)]
    [Column(Constants.Entities.CommonProperties.ID_PROFILE, Order = 2)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_ID_PROFILE)]
    public Guid IdProfile { get; set; }

    [ForeignKey(Constants.Entities.ForeignsKeys.FOREIGN_KEY_MODULE)]
    [Column(Constants.Entities.CommonProperties.ID_MODULE, Order = 3)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_ID_MODULE)]
    public Guid IdModule { get; set; }

    [Column(Constants.Entities.CommonProperties.CREATE_AT, Order = 4)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_CREATE_AT)]
    public DateTime CreateAt { get; set; }

    public virtual Profile Profile { get; set; } = null!;

    public virtual Module Module { get; set; } = null!;
}