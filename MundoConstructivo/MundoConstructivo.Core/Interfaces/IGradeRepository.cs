using MundoConstructivo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundoConstructivo.Core.Interfaces
{
    public interface IGradeRepository
    {
        Task<IEnumerable<Grade>> GetGrades(int? studentId, int? courseId);
        Task<Grade> GetGrade(int id);
        Task InsertGrade(Grade grade, string userEmail);
        Task<bool> UpdateGrade(Grade grade,string userEmail);
        Task<bool> DeleteGrade(int id);
    }
}
