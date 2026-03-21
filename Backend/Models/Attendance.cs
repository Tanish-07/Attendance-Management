using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("Attendance")]
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int ClassId { get; set; }

        public DateTime AttendanceDate { get; set; }

        public string Status { get; set; }
    }
}
