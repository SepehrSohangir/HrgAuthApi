using AutoMapper;
using HrgAuthApi.Models;

namespace HrgAuthApi.MapperProfile
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            CreateMap<Users, Dto.ClaimsDto>()
                .ForMember(e => e.Name, opt => opt.MapFrom(w => w.UserName))
                .ForMember(e => e.Surname, opt => opt.MapFrom(w => w.Surname))
                .ForMember(e => e.UserIdString, opt => opt.MapFrom(w => Convert.ToString(w.UserId)))
                .ForMember(e => e.CompanyIdString, opt => opt.MapFrom(w => Convert.ToString(w.CompanyID)))
                .ForPath(e => e.PermissionCode, opt => opt.MapFrom(w => (w.UserGroup ?? new UserGroups()).PermissionCode));
                
        }
    }
}
