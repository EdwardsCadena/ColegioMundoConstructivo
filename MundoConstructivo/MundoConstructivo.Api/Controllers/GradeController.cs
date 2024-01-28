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
    public class GradeController : ControllerBase
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;

        public GradeController(IGradeRepository gradeRepository, IMapper mapper)
        {
            _gradeRepository = gradeRepository;
            _mapper = mapper;
        }

        // GET: api/<GradeController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetGrades(int? studentId, int? courseId)
        {
            var grades = await _gradeRepository.GetGrades(studentId, courseId);
            var gradesDto = _mapper.Map<IEnumerable<GradeDTOs>>(grades);
            return Ok(gradesDto);
        }

        // GET api/<GradeController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetGrade(int id)
        {
            var grade = await _gradeRepository.GetGrade(id);
            var gradeDto = _mapper.Map<GradeDTOs>(grade);
            return Ok(gradeDto);
        }

        // POST api/<GradeController>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostGrade(GradeDTOs gradeDto)
        {
            var grade = _mapper.Map<Grade>(gradeDto);
            var userEmail = User.Identity.Name;
            await _gradeRepository.InsertGrade(grade, userEmail);
            var updatedto = new ApiResponse<GradeDTOs>(gradeDto);
            return Ok(updatedto);
        }

        // PUT api/<GradeController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutGrade(int id, Grade gradeDto)
        {
            var grade = _mapper.Map<Grade>(gradeDto);
            grade.Id = id;
            var userEmail = User.Identity.Name;
            var Update = await _gradeRepository.UpdateGrade(grade, userEmail);
            var updatedto = new ApiResponse<bool>(Update);
            return Ok(updatedto);
        }

        // DELETE api/<GradeController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var result = await _gradeRepository.DeleteGrade(id);
            var delete = new ApiResponse<bool>(result);
            return Ok(delete);
        }
    }
}
