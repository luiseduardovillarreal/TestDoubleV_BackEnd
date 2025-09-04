using Microsoft.EntityFrameworkCore;
using Movement.Domain.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movement.Domain.Entities;

#pragma warning disable CS8618

[Table(Constants.Entities.Profile.TBL_PROFILE)]
[Index(nameof(Code), IsUnique = true)]
[Index(nameof(Name), IsUnique = true)]
public partial class Profile
{
    [Key]
    [Column(Constants.Entities.CommonProperties.ID, Order = 1)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_ID)]
    public Guid Id { get; set; }

    [Required]
    [Precision(3)]
    [Column(Constants.Entities.CommonProperties.CODE, Order = 2)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_CODE)]
    public byte Code { get; set; }

    [Required]
    [StringLength(100)]
    [Column(Constants.Entities.Profile.NAME, Order = 3)]
    [Comment(Constants.Entities.Profile.COMMENTS_ON_NAME)]
    public string Name { get; set; }

    [Required]
    [StringLength(4000)]
    [Column(Constants.Entities.Profile.DESCRIPTION, Order = 4)]
    [Comment(Constants.Entities.Profile.COMMENTS_ON_DESCRIPTION)]
    public string Description { get; set; }
    
    [Column(Constants.Entities.CommonProperties.CREATE_AT, Order = 5)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_CREATE_AT)]
    public DateTime CreateAt { get; set; }

    [Column(Constants.Entities.CommonProperties.UPDATE_AT, Order = 6)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_UPDATE_AT)]
    public DateTime? UpdateAt { get; set; }

    [Column(Constants.Entities.CommonProperties.IS_ACTIVE, Order = 7)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_IS_ACTIVE)]
    public bool IsActive { get; set; }

    public virtual ICollection<User_Profile> Users_Profiles { get; } = new List<User_Profile>();

    public virtual ICollection<Profile_Module> Profiles_Modules { get; } = new List<Profile_Module>();

    public virtual ICollection<Profile_SubModule> Profiles_SubModules { get; } = new List<Profile_SubModule>();
}