
using AutoMapper;
using CodeFirstSingleTable.Models;

namespace CodeFirstSingleTable.Mappings
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentDto>();
        }
    }
}
