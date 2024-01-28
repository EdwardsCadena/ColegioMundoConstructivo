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
    public class StudentRepository : IStudentRepository
    {
        private readonly ColegioMundoConstructivoContext _context;
        DateTime currentDate = DateTime.Now;
        public StudentRepository(ColegioMundoConstructivoContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetStudents(int pageNumber, int pageSize)
        {
            // Calcular el número de estudiantes a saltar
            int skip = (pageNumber - 1) * pageSize;

            // Obtener los estudiantes paginados
            var students = await _context.Students
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();
            return students;
        }
        public async Task<Student> GetStudent(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            return student;
        }

        // Método para obtener el total de estudiantes
        public async Task<int> GetTotalStudents()
        {
            return await _context.Students.CountAsync();
        }

        public async Task InsertStudent(Student student, string  userEmail)
        {

            Student register = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                IdentityDocument = student.IdentityDocument,
                CellPhone = student.CellPhone,
                Email = student.Email,
                BirthDate = student.BirthDate,
                CreatedAt = currentDate,
                CreatedBy = userEmail
            };
            _context.Students.Add(register);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateStudent(Student student, string userEmail)
        {
            var result = await GetStudent(student.Id);
            result.FirstName = student.FirstName;
            result.LastName = student.LastName;
            result.IdentityDocument = student.IdentityDocument;
            result.CellPhone = student.CellPhone;
            result.Email = student.Email;
            result.BirthDate = student.BirthDate;
            result.UpdatedAt = currentDate;
            result.UpdatedBy = userEmail; // Asignar el correo electrónico del usuario a UpdatedBy
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> DeleteStudent(int id)
        {
            var delete = await GetStudent(id);
            _context.Remove(delete);
            int row = await _context.SaveChangesAsync();
            return row > 0;
        }
    }
}
