using Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        // Get students by class with name
        [HttpGet("by-class/{classId}")]
        public IActionResult GetStudentsByClass(int classId)
        {
            try
            {
                var students = (from s in _context.Students
                                join u in _context.SaveSignUp
                                on s.UserId equals u.userId
                                where s.ClassId == classId
                                select new
                                {
                                    s.StudentId,
                                    s.RollNumber,
                                    StudentName = u.fullName,
                                    Email = u.emailId
                                }).ToList();

                if (students.Count == 0)
                {
                    return NotFound(new
                    {
                        message = "No students found for this class"
                    });
                }

                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error fetching students",
                    error = ex.Message
                });
            }
        }
    }
}