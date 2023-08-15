using System.ComponentModel.DataAnnotations;

namespace HrgAuthApi.Dto
{
    public class ClaimsDto
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string PermissionCode { get; set; } = string.Empty;
        public string UserIdString { get; set; } = string.Empty;
        public string CompanyIdString { get; set; } = string.Empty;
    }
}
