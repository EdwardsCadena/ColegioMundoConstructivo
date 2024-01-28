using MundoConstructivo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundoConstructivo.Core.Interfaces
{
    public interface ICourseRepository
    {
        // Este método devuelve una tarea que representa una colección de cursos
        Task<IEnumerable<Course>> GetCourses(string? teacherName = null);

        // Este método devuelve una tarea que representa un único curso
        // Se espera que el curso devuelto tenga el ID proporcionado
        Task<Course> GetCourse(int id);

        // Este método recibe un objeto Course y no devuelve nada e inserta el curso proporcionado en la base de datos
        Task InsertCourse(Course course, string userEmail);

        // Este método recibe un objeto Course y devuelve una tarea que representa un valor booleano, donde actuliza el curso con sus nuevos paramteros
        Task<bool> UpdateCourse(Course course, string userEmail);

        // Este método recibe un ID de curso donde el metodo elimina el curso de la base de datos
        Task<bool> DeleteCourse(int id);
    }
}
