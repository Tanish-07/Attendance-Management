using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public int UserId { get; set; }  // FK → userLog

        public string RollNumber { get; set; }

        public int ClassId { get; set; }
    }
}
