using AutoMapper;
using WebApplication10.Model;

namespace WebApplication10.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            /// source   ,  des
            CreateMap<StudentRegister, Student>();

            /// source   ,  des
            CreateMap<Student, StudentRegister>();

        }
    }
}