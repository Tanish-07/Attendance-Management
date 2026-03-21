using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{

    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string Section { get; set; }
    }
}
