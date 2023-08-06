using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrgAuthApi.Models;

public class UserGroups
{
    public short GroupCode { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    public string? GroupName { get; set; }
    [Column(TypeName = "nvarchar(400)")]
    public string? Comment { get; set; }
    [Column(TypeName = "varchar(MAX)")]
    public string? PermissionCode { get; set; }
    public ICollection<Users>? Users { get; }
}
