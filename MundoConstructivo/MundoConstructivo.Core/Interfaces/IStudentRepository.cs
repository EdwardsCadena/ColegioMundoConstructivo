using MundoConstructivo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundoConstructivo.Core.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents(int pageNumber, int pageSize);
        Task<Student> GetStudent(int id);
        Task InsertStudent(Student student, string userEmail);
        Task<bool> UpdateStudent(Student student, string userEmail);
        Task<bool> DeleteStudent(int id);
        Task<int> GetTotalStudents();
    }
}
