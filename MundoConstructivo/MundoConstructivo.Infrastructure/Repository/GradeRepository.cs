using Microsoft.EntityFrameworkCore;
using MundoConstructivo.Core.Entities;
using MundoConstructivo.Core.Interfaces;
using MundoConstructivo.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundoConstructivo.Infrastructure.Repository
{
    public class GradeRepository : IGradeRepository
    {
        private readonly ColegioMundoConstructivoContext _context;

        public GradeRepository(ColegioMundoConstructivoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Grade>> GetGrades(int? studentId, int? courseId)
        {
            IQueryable<Grade> query = _context.Grades;

            if (studentId != null)
            {
                query = query.Where(g => g.StudentId == studentId);
            }

            if (courseId != null)
            {
                query = query.Where(g => g.CourseId == courseId);
            }

            return await query.ToListAsync();
        }

        public async Task<Grade> GetGrade(int id)
        {
            var grade = await _context.Grades.FirstOrDefaultAsync(x => x.Id == id);
            return grade;
        }

        public async Task InsertGrade(Grade grade, string userEmail)
        {
            Grade newGrade = new Grade
            {
                Score = grade.Score,
                StudentId = grade.StudentId,
                CourseId = grade.CourseId,
                CreatedAt = DateTime.Now,
                CreatedBy = userEmail
            };

            _context.Grades.Add(newGrade);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateGrade(Grade grade, string userEmail)
        {
            var existingGrade = await GetGrade(grade.Id);

            existingGrade.Score = grade.Score;
            existingGrade.StudentId = grade.StudentId;
            existingGrade.CourseId = grade.CourseId;
            existingGrade.UpdatedAt = DateTime.Now;
            existingGrade.UpdatedBy = userEmail;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteGrade(int id)
        {
            var gradeToDelete = await GetGrade(id);
            _context.Grades.Remove(gradeToDelete);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
