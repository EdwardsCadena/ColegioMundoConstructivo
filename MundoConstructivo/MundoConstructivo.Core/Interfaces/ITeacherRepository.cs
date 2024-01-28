using MundoConstructivo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundoConstructivo.Core.Interfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetTeachers();
        Task<Teacher> GetTeacher(int id);
        Task InsertTeacher(Teacher teacher, string UserEmail);
        Task<bool> UpdateTeacher(Teacher teacher, string UserEmail);
        Task<bool> DeleteTeacher(int id);
    }
}
