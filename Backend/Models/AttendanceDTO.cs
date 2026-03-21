namespace Backend.Models
{
    public class AttendanceDTO
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int ClassId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Status { get; set; }
    }
}
