using Microsoft.EntityFrameworkCore;
using I_AM.Domain.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace I_AM.Domain.Entities;

#pragma warning disable CS8618

[Table(Constants.Entities.TokenInquest.TBL_TOKEN_INQUEST)]
[Index(nameof(Token), IsUnique = true)]
public partial class TokenInquest(Guid idInquest, string token, bool thisUniqueResponse, 
    bool thisOpen)
{
    [Key]
    [Column(Constants.Entities.CommonProperties.ID, Order = 1)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_ID)]
    public Guid Id { get; set; }

    [ForeignKey(Constants.Entities.ForeignsKeys.FOREIGN_KEY_INQUEST)]
    [Column(Constants.Entities.CommonProperties.ID_INQUEST, Order = 2)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_ID_INQUEST)]
    public Guid IdInquest { get; set; } = idInquest;

    [Required]
    [StringLength(250)]
    [Column(Constants.Entities.TokenInquest.TOKEN, Order = 3)]
    [Comment(Constants.Entities.TokenInquest.COMMENTS_ON_TOKEN)]
    public string Token { get; set; } = token;

    [Column(Constants.Entities.CommonProperties.CREATE_AT, Order = 4)]
    [Comment(Constants.Entities.CommonComents.COMMENTS_ON_PROPERTIES_CREATE_AT)]
    public DateTime CreateAt { get; set; } = DateTime.Now;

    [Column(Constants.Entities.TokenInquest.THIS_UNIQUE_RESPONSE, Order = 5)]
    [Comment(Constants.Entities.TokenInquest.COMMENTS_ON_THIS_UNIQUE_RESPONSE)]
    public bool ThisUniqueResponse { get; set; } = thisUniqueResponse;

    [Column(Constants.Entities.TokenInquest.THIS_OPEN, Order = 6)]
    [Comment(Constants.Entities.TokenInquest.COMMENTS_ON_THIS_OPEN)]
    public bool ThisOpen { get; set; } = thisOpen;
}