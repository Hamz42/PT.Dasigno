using AutoMapper;
using PT.Dasigno.DAL.Context.ContextDasigno.Entities;
using PT.Dasigno.DTO.Users;

namespace PT.Dasigno.BLL.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Users, UserDto>();
        }
    }
}
