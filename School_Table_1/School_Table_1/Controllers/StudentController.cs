using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Table_1.Context;
using School_Table_1.Dtos;
using School_Table_1.Entities;

namespace School_Table_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult CreateStudent(StudentDTO model)
        {
            Student student = new()
            {
                Name = model.Name,
                LastName = model.LastName,
                RegisterYear = model.RegisterYear,
                Grade = model.Grade,
                Description = model.Description,
                CategoryId = model.CategoryId,
            };
            _context.Students.Add(student);
            if (_context.SaveChanges() > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

       

        [HttpDelete("{studentId}")]
        public ActionResult DeleteStudent([FromRoute] Guid studentId)
        {
            var student = _context.Students.Find(studentId);
            if (student != null)
            {
                _context.Students.Remove(student);
                if (_context.SaveChanges() > 0)
                {

                    return Ok();
                }

            }
            return BadRequest();

        }

            [HttpGet]
        public ActionResult GetAllStudent()
        {
            List<Student> students = _context.Students.ToList();
            if (students is not null)
            {
                return Ok(students);
            }
            return NotFound();
        }
        [HttpPut("{studentId}")]
        public ActionResult UpdateStudent([FromRoute] Guid studentId, StudentDTO model)
        {
            var student = _context.Students.Find(studentId);
            if (student is not null)
            {
                student.Name = model.Name;
                student.Description = model.Description;
                student.LastName = model.LastName;
                student.RegisterYear = model.RegisterYear;
                student.CategoryId = model.CategoryId;
                student.Grade=model.Grade;
                if (_context.SaveChanges() > 0)
                {

                return Ok(model);
                }
            }
            
            return NotFound();
        }
        [HttpGet("Student/{studentId}")]
        public ActionResult GetStudentById([FromRoute] Guid studentId)
        {
            Student student = _context.Students.Find(studentId);
            if (student is not null)
            {
                return Ok(student);
            }
            return NotFound();
        }
        [HttpGet("{categoryId}")]
        public ActionResult GetStudentByCategoryId([FromRoute] Guid categoryId)
        {
            List<Student> students = _context.Students.Where(x => x.CategoryId == categoryId).ToList();
            if (students is not null)
            {
                return Ok(students);
            }
            return NotFound();
        }
    }
}
