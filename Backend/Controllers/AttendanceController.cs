using Backend.Model;
using Backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class AttendanceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AttendanceController(AppDbContext context)
        {
            _context = context;
        }

        // MARK ATTENDANCE
        [HttpPost("mark")]
        public IActionResult MarkAttendance(List<AttendanceDTO> attendanceList)
        {
            try
            {
                if (attendanceList == null || attendanceList.Count == 0)
                {
                    return BadRequest(new
                    {
                        message = "Attendance list is empty"
                    });
                }

                foreach (var record in attendanceList)
                {
                    // 🔍 Validate Student
                    var studentExists = _context.Students.Any(s => s.StudentId == record.StudentId);
                    if (!studentExists)
                    {
                        return BadRequest(new
                        {
                            message = $"Invalid StudentId: {record.StudentId}"
                        });
                    }

                    // 🔍 Validate Subject
                    var subjectExists = _context.Subjects.Any(s => s.SubjectId == record.SubjectId);
                    if (!subjectExists)
                    {
                        return BadRequest(new
                        {
                            message = $"Invalid SubjectId: {record.SubjectId}"
                        });
                    }

                    // 🔍 Validate Class
                    var classExists = _context.Classes.Any(c => c.ClassId == record.ClassId);
                    if (!classExists)
                    {
                        return BadRequest(new
                        {
                            message = $"Invalid ClassId: {record.ClassId}"
                        });
                    }

                    // 🔁 Check duplicate
                    var exists = _context.Attendances.Any(a =>
                        a.StudentId == record.StudentId &&
                        a.SubjectId == record.SubjectId &&
                        a.AttendanceDate == record.AttendanceDate);

                    if (!exists)
                    {
                        var attendance = new Attendance
                        {
                            StudentId = record.StudentId,
                            SubjectId = record.SubjectId,
                            ClassId = record.ClassId,
                            AttendanceDate = record.AttendanceDate,
                            Status = record.Status
                        };

                        _context.Attendances.Add(attendance);
                    }
                }

                _context.SaveChanges();

                return Ok(new
                {
                    message = "Attendance marked successfully"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error marking attendance",
                    error = ex.Message
                });
            }
        }

        // GET STUDENT ATTENDANCE
        [HttpGet("student/{studentId}")]
        public IActionResult GetStudentAttendance(int studentId)
        {
            try
            {
                var attendance = (from a in _context.Attendances
                                  join sub in _context.Subjects
                                  on a.SubjectId equals sub.SubjectId
                                  where a.StudentId == studentId
                                  group a by sub.SubjectName into g
                                  select new
                                  {
                                      Subject = g.Key,
                                      TotalClasses = g.Count(),
                                      Present = g.Count(x => x.Status == "Present")
                                  }).ToList();

                return Ok(attendance);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error fetching attendance",
                    error = ex.Message
                });
            }
        }
    }
}