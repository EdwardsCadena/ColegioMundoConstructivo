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
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ColegioMundoConstructivoContext _context;
        DateTime currentDate = DateTime.Now;
        public TeacherRepository(ColegioMundoConstructivoContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Teacher>> GetTeachers()
        {
            var teachers = await _context.Teachers.ToListAsync();
            return teachers;
        }
        public async Task<Teacher> GetTeacher(int id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);
            return teacher;
        }
        public async Task InsertTeacher(Teacher teacher, string UserEmail)
        {
            
            Teacher register = new Teacher
            {
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                IdentityDocument = teacher.IdentityDocument,
                CellPhone = teacher.CellPhone,
                Email = teacher.Email,
                BirthDate = teacher.BirthDate,
                CreatedAt = currentDate,
                CreatedBy = UserEmail
            };
            _context.Teachers.Add(register);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateTeacher(Teacher teacher, string UserEmail)
        {
            var result = await GetTeacher(teacher.Id);
            result.FirstName = teacher.FirstName;
            result.LastName = teacher.LastName;
            result.IdentityDocument = teacher.IdentityDocument;
            result.CellPhone = teacher.CellPhone;
            result.Email = teacher.Email;
            result.BirthDate = teacher.BirthDate;
            result.UpdatedAt = currentDate;
            result.UpdatedBy = UserEmail;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> DeleteTeacher(int id)
        {
            var delete = await GetTeacher(id);
            _context.Remove(delete);
            int row = await _context.SaveChangesAsync();
            return row > 0;
        }

    }
}
