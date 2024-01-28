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
    public class CourseRepository : ICourseRepository
    {
        // Aquí defino una variable privada para el contexto de la base de datos
        private readonly ColegioMundoConstructivoContext _context;

        // Este es el constructor del repositorio, donde el contexto de la base de datos es inyectado
        public CourseRepository(ColegioMundoConstructivoContext context)
        {
            // El contexto de la base de datos inyectado se asigna a la variable privada para ser usado en métodos 
            _context = context;
        }

        // Este método devuelve una colección de todos los cursos en la base de datos
        public async Task<IEnumerable<Course>> GetCourses(string? teacherName = null)
        {
            // Aquí se crea una consulta que obtendrá los cursos de la base de datos
            // Include asegura que los datos del profesor se carguen junto con cada curso
            IQueryable<Course> query = _context.Courses.Include(c => c.Teacher);
            // Si se ha proporcionado un nombre de profesor, se filtran los cursos para incluir solo aquellos
            // cursos que dicta el profesor
            if (!string.IsNullOrEmpty(teacherName))
            {
                query = query.Where(c => c.Teacher.FirstName.Contains(teacherName) || c.Teacher.LastName.Contains(teacherName));
            }

            return await query.ToListAsync();
        }

        // Este método devuelve un curso específico de la base de datos basado en el ID proporcionado
        public async Task<Course> GetCourse(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            return course;
        }

        // Este método inserta un nuevo curso en la base de datos
        public async Task InsertCourse(Course course, string userEmail)
        {
            Course newCourse = new Course
            {
                Name = course.Name,
                TeacherId = course.TeacherId,
                CreatedAt = DateTime.Now,
                CreatedBy = userEmail
            };

            _context.Courses.Add(newCourse);
            await _context.SaveChangesAsync();
        }

        // Este método actualiza un curso existente en la base de datos
        public async Task<bool> UpdateCourse(Course course, string userEmail)
        {
            var existingCourse = await GetCourse(course.Id);

            existingCourse.Name = course.Name;
            existingCourse.TeacherId = course.TeacherId;
            existingCourse.UpdatedAt = DateTime.Now;
            existingCourse.UpdatedBy = userEmail;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        // Este método elimina un curso existente de la base de datos
        public async Task<bool> DeleteCourse(int id)
        {
            var courseToDelete = await GetCourse(id);
            _context.Courses.Remove(courseToDelete);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
