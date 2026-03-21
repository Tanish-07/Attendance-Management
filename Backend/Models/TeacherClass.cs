using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class TeacherClass
    {
        [Key]
        public int Id { get; set; }

        public int TeacherId { get; set; }  // FK → adminCredentials
        public int ClassId { get; set; }
    }
}
