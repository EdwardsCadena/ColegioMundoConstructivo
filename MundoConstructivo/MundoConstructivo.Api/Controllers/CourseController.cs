using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MundoConstructivo.Api.Response;
using MundoConstructivo.Core.Dtos;
using MundoConstructivo.Core.Entities;
using MundoConstructivo.Core.Interfaces;
using MundoConstructivo.Infrastructure.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MundoConstructivo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        // Aquí defino las dependencias que serán inyectadas en el controlador
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        // Este es el constructor del controlador, donde las dependencias son inyectadas
        public CourseController(ICourseRepository courseRepository, IMapper mapper)
        {
            // Las dependencias inyectadas se asignan a las variables privadas para ser usadas en los métodos del controlador
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        // Devuelve una lista de todos los cursos
        // GET: api/<CourseController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCourses(string? teacherName = null)
        {
            // Obtiene los cursos de la base de datos usando el repositorio
            var courses = await _courseRepository.GetCourses(teacherName);
            // Mapea los cursos a mi DTO (Data Transfer Object)
            var coursesDto = _mapper.Map<IEnumerable<CourseDTOs>>(courses);
            return Ok(coursesDto);
        }

        // Devuelve un curso específico basado en el ID proporcionado
        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetCourse(int id)
        {
            var course = await _courseRepository.GetCourse(id);
            var courseDto = _mapper.Map<CourseDTOs>(course);
            return Ok(courseDto);
        }

        // Crea un nuevo curso con los datos proporcionados
        // POST api/<CourseController>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostCourse(CourseDTOs courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            var userEmail = User.Identity.Name;  // Obtener el correo electrónico del usuario autenticado
            await _courseRepository.InsertCourse(course, userEmail);
            var updatedto = new ApiResponse<CourseDTOs>(courseDto);
            return Ok(updatedto);
        }

        // Actualiza un curso existente basado en el Id
        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutCourse(int id, Course courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            course.Id = id;
            var userEmail = User.Identity.Name;  // Obtener el correo electrónico del usuario autenticado
            var Update = await _courseRepository.UpdateCourse(course, userEmail);
            var updatedto = new ApiResponse<bool>(Update);
            return Ok(updatedto);
        }

        // Elimina un curso existente basado en el ID proporcionado
        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await _courseRepository.DeleteCourse(id);
            var delete = new ApiResponse<bool>(result);
            return Ok(delete);
        }
    }
}
