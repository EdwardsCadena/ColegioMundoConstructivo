using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MundoConstructivo.Api.Response;
using MundoConstructivo.Core.Dtos;
using MundoConstructivo.Core.Entities;
using MundoConstructivo.Core.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MundoConstructivo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetStudents(int pageNumber = 1, int pageSize = 10)
        {
            // Obtiene una página de estudiantes de la base de datos usando el repositorio
            // Si no se proporcionan los parámetros pageNumber y pageSize, se usan los valores por defecto (1 y 10 respectivamente)
            var students = await _studentRepository.GetStudents(pageNumber, pageSize);

            // Mapea los estudiantes a un DTO (Data Transfer Object)
            var studentsDto = _mapper.Map<IEnumerable<StudentDTOs>>(students);

            // Crear el objeto de respuesta que incluye el número de página, el tamaño de la página,
            // el conteo total de estudiantes y la lista de estudiantes en la página actual
            var response = new
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = await _studentRepository.GetTotalStudents(),
                Data = studentsDto
            };

            // Devuelve la respuesta con un código de estado HTTP 200 (OK)
            return Ok(response);
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _studentRepository.GetStudent(id);
            var studentDto = _mapper.Map<StudentDTOs>(student);
            return Ok(studentDto);
        }

        // POST api/<StudentController>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostStudent(StudentDTOs studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            var userEmail = User.Identity.Name;  // Obtener el correo electrónico del usuario autenticado
            await _studentRepository.InsertStudent(student, userEmail);
            
            var updatedto = new ApiResponse<StudentDTOs>(studentDto);
            return Ok(updatedto);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutStudent(int id, Student studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            student.Id = id;
            var userEmail = User.Identity.Name;  // Obtener el correo electrónico del usuario autenticado
            var Update = await _studentRepository.UpdateStudent(student, userEmail);  // Pasarlo como un parámetro al método del repositori
            var updatedto = new ApiResponse<bool>(Update);
            return Ok(updatedto);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentRepository.DeleteStudent(id);
            var delete = new ApiResponse<bool>(result);
            return Ok(delete);
        }
    }
}
