using Backend.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class ClassesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClassesController(AppDbContext context)
        {
            _context = context;
        }

        // Get classes assigned to teacher
        [HttpGet("my-classes/{teacherId}")]
        public IActionResult GetTeacherClasses(int teacherId)
        {
            try
            {
                var classes = (from c in _context.Classes
                               join tc in _context.TeacherClasses
                               on c.ClassId equals tc.ClassId
                               where tc.TeacherId == teacherId
                               select new
                               {
                                   c.ClassId,
                                   c.ClassName,
                                   c.Section
                               }).ToList();

                return Ok(classes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error fetching classes",
                    error = ex.Message
                });
            }
        }

        [HttpGet("subjects/{classId}")]
        public IActionResult GetSubjectsByClass(int classId)
        {
            try
            {
                var subjects = _context.Subjects
                    .Where(s => s.ClassId == classId)
                    .Select(s => new
                    {
                        s.SubjectId,
                        s.SubjectName
                    })
                    .ToList();

                if (subjects.Count == 0)
                {
                    return NotFound(new
                    {
                        message = "No subjects found for this class"
                    });
                }

                return Ok(subjects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error fetching subjects",
                    error = ex.Message
                });
            }
        }
    }
}
