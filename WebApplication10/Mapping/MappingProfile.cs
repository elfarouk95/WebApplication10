using AutoMapper;
using WebApplication10.Model;

namespace WebApplication10.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentRegister, Student>();
        }
    }
}
