using Microsoft.AspNetCore.Mvc;
using MundoConstructivo.Api.Response;
using MundoConstructivo.Core.Dtos;
using MundoConstructivo.Core.Entities;
using MundoConstructivo.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MundoConstructivo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _maper;
        public TeacherController(ITeacherRepository personRepository, IMapper mapper)
        {
            _teacherRepository = personRepository;
            _maper = mapper;
        }

        // GET: api/<PersonsController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetTeachers()
        {
            var people = await _teacherRepository.GetTeachers();
            var peoplesdto = _maper.Map<IEnumerable<TeacherDTOs>>(people);
            return Ok(peoplesdto);
        }

        // GET api/<PersonsController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetTeacher(int id)
        {
            var people = await _teacherRepository.GetTeacher(id);
            var peopledto = _maper.Map<TeacherDTOs>(people);
            return Ok(peopledto);
        }

        // POST api/<PersonsController>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostTeacher(TeacherDTOs peopledto)
        {
            var peolpe = _maper.Map<Teacher>(peopledto);
            var userEmail = User.Identity.Name;  // Obtener el correo electrónico del usuario autenticado

            await _teacherRepository.InsertTeacher(peolpe, userEmail);
            var updatedto = new ApiResponse<TeacherDTOs>(peopledto);
            return Ok(updatedto);
        }

        // PUT api/<PersonsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutTeacher(int id, Teacher peopledto)
        {
            var serv = _maper.Map<Teacher>(peopledto);
            serv.Id = id;
            var userEmail = User.Identity.Name;  // Obtener el correo electrónico del usuario autenticado

            var Update = await _teacherRepository.UpdateTeacher(serv, userEmail);
            var updatedto = new ApiResponse<bool>(Update);
            return Ok(updatedto);
        }

        // DELETE api/<PersonsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var result = await _teacherRepository.DeleteTeacher(id);
            var delete = new ApiResponse<bool>(result);
            return Ok(delete);
        }
    }
}
