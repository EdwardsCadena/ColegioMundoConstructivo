using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MundoConstructivo.Core.Dtos;
using MundoConstructivo.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundoConstructivo.Infrastructure.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            // Estas líneas crean mapas bidireccionales entre las entidades y sus correspondientes DTOs
            // //con esto puedo mapear un objeto Teacher a un objeto TeacherDTOs y viceversa
            CreateMap<Teacher, TeacherDTOs>();
            CreateMap<TeacherDTOs, Teacher>();

            CreateMap<Student, StudentDTOs>();
            CreateMap<StudentDTOs, Student>();

            CreateMap<Course, CourseDTOs>();
            CreateMap<CourseDTOs, Course>();

            CreateMap<Grade, GradeDTOs>();
            CreateMap<GradeDTOs, Grade>();

            CreateMap<User, UserDTOs>();
            CreateMap<UserDTOs, User>();

        }
    }
}
