using System.ComponentModel.DataAnnotations;

namespace UnitedSystemsCooperative.Web.Shared.JoinRequest;

public class AmbassadorJoinRequest : JoinRequestBase
{
    [Required]
    public string? Group { get; set; }

    public bool NeedPrivate { get; set; } = false;
    
}