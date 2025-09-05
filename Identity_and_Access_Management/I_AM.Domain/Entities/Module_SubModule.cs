using Microsoft.EntityFrameworkCore;
using I_AM.Domain.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace I_AM.Domain.Entities;

[Table(Constants.Entities.Module_SubModule.TBL_MODULE_SUB_MODULE)]
public partial class Module_SubModule
{
    [Key]
    [Column(Constants.Entities.CommonProperties.ID, Order = 1)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_ID)]
    public Guid Id { get; set; }

    [ForeignKey(Constants.Entities.ForeignsKeys.FOREIGN_KEY_MODULE)]
    [Column(Constants.Entities.CommonProperties.ID_MODULE, Order = 2)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_ID_MODULE)]
    public Guid IdModule { get; set; }

    [ForeignKey(Constants.Entities.ForeignsKeys.FOREIGN_KEY_SUB_MODULE)]
    [Column(Constants.Entities.CommonProperties.ID_SUB_MODULE, Order = 3)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_ID_SUB_MODULE)]
    public Guid IdSubModule { get; set; }

    [Column(Constants.Entities.CommonProperties.CREATE_AT, Order = 4)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_CREATE_AT)]
    public DateTime CreateAt { get; set; }   

    public virtual Module Module { get; set; } = null!;

    public virtual SubModule SubModule { get; set; } = null!;
}