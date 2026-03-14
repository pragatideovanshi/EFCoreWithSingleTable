using AutoMapper;
using CodeFirstSingleTable.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CodeFirstSingleTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDBContext _context;
        private readonly IMapper _mapper;
        public StudentsController(StudentDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()  // Understand Why Ienumerable
        {
      
        var result = await _context.Students.ToListAsync();
        return result;
          
        }

        // GET: api/students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            return student;
        }

        // POST: api/students
        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(StudentDto dto)
        {
            try
            {
                //var student = new Student
                //{
                //    Name = dto.Name,
                //    Gender = dto.Gender,
                //    Age = dto.Age
                //};
                var student = _mapper.Map<Student>(dto);
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }

            return Ok(dto);
        }

        // PUT: api/students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            if (id != student.Id)
                return BadRequest();

            var existingStudent = await _context.Students.FindAsync(id);

            if (existingStudent == null)
                return NotFound();

            existingStudent.Name = student.Name;
            existingStudent.Age = student.Age;

            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}