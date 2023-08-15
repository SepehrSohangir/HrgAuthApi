using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrgAuthApi.Models;

public class Users
{
    public int UserId { get; set; }
    [Column(TypeName = "nvarchar(20)")]
    public string? FirstName { get; set; }
    [Column(TypeName = "nvarchar(30)")]
    public string? Surname { get; set; }
    [Column(TypeName = "nvarchar(15)")]
    public string? IdNumber { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    public string? Organ { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    public string? Post { get; set; }
    [Column(TypeName = "nvarchar(20)")]
    public string? UserName { get; set; }
    public short? GroupCode { get; set; }
    [Column(TypeName = "varbinary(MAX)")]
    public byte[]? Password { get; set; }
    [Column(TypeName = "nvarchar(8)")]
    public string? PukCode { get; set; }
    [Column(TypeName = "image")]
    public byte[]? Picture { get; set; }
    public int CompanyID { get; set; }
    public int? PID { get; set; }
    public short startPageMode { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    public string? UserWord { get; set; }
    public bool DisableUser { get; set; }
    public int ID { get; set; }
    [Column(TypeName = "varchar(128)")]
    public string? usrPasswordSalt { get; set; }
    public bool UserMustChangePassword { get; set; }
    public int? LastPasswordChange { get; set; }
    public bool PTAC { get; set; }
    [Column(TypeName = "char(11)")]
    public string? Phonenumber { get; set; }
    [Column(TypeName = "varchar(8)")]
    public string LastLoginDate { get; set; } = string.Empty;
    [Column(TypeName = "varbinary(MAX)")]
    public byte[]? Signature { get; set; }
    public UserGroups? UserGroup { get; set; }
}
