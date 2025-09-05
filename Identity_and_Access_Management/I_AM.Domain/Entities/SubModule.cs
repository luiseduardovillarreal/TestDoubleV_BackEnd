using Microsoft.EntityFrameworkCore;
using I_AM.Domain.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace I_AM.Domain.Entities;

#pragma warning disable CS8618

[Table(Constants.Entities.SubModule.TBL_SUB_MODULE)]
[Index(nameof(Name), IsUnique = true)]
public partial class SubModule
{
    [Key]
    [Column(Constants.Entities.CommonProperties.ID, Order = 1)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_ID)]
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    [Column(Constants.Entities.SubModule.NAME, Order = 2)]
    [Comment(Constants.Entities.SubModule.COMMENTS_ON_NAME)]
    public string Name { get; set; }

    [Required]
    [StringLength(4000)]
    [Column(Constants.Entities.SubModule.DESCRIPTION, Order = 3)]
    [Comment(Constants.Entities.SubModule.COMMENTS_ON_DESCRIPTION)]
    public string Description { get; set; }

    [Required]
    [StringLength(100)]
    [Column(Constants.Entities.SubModule.ROUTER_LINK, Order = 4)]
    [Comment(Constants.Entities.SubModule.COMMENTS_ON_ROUTER_LINK)]
    public string RouterLink { get; set; }

    [Column(Constants.Entities.CommonProperties.CREATE_AT, Order = 5)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_CREATE_AT)]
    public DateTime CreateAt { get; set; }

    [Column(Constants.Entities.CommonProperties.UPDATE_AT, Order = 6)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_UPDATE_AT)]
    public DateTime? UpdateAt { get; set; }

    [Column(Constants.Entities.CommonProperties.IS_ACTIVE, Order = 7)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_IS_ACTIVE)]
    public bool IsActive { get; set; }

    public virtual ICollection<Module_SubModule> Modules_SubModules { get; } = new List<Module_SubModule>();

    public virtual ICollection<Profile_SubModule> Profiles_SubModules { get; } = new List<Profile_SubModule>();
}