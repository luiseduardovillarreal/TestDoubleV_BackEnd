using Microsoft.EntityFrameworkCore;
using Movement.Domain.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movement.Domain.Entities;

[Table(Constants.Entities.User_Rol.TBL_USER_ROL)]
public partial class User_Rol
{
    [Key]
    [Column(Constants.Entities.CommonProperties.ID, Order = 1)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_ID)]
    public Guid Id { get; set; }

    [ForeignKey(Constants.Entities.ForeignsKeys.FOREIGN_KEY_USER)]
    [Column(Constants.Entities.CommonProperties.ID_USER, Order = 2)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_ID_USER)]
    public Guid IdUser { get; set; }

    [ForeignKey(Constants.Entities.ForeignsKeys.FOREIGN_KEY_ROL)]
    [Column(Constants.Entities.User_Rol.ID_ROL, Order = 3)]
    [Comment(Constants.Entities.User_Rol.COMMENTS_ON_ID_ROL)]
    public Guid IdRol { get; set; }

    [Column(Constants.Entities.CommonProperties.CREATE_AT, Order = 4)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_CREATE_AT)]
    public DateTime CreateAt { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual Rol Rol { get; set; } = null!;
}