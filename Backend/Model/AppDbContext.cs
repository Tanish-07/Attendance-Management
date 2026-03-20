using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<SignUp> SaveSignUp { get; set; }

        public DbSet<adminLogin> AdminLogins { get; set; }


        //ContactMessage Table
        [Table("contactMessage")]
        public class ContactMessage
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int contactId { get; set; }
            public string fullName { get; set; } = null;
            public string emailId { get; set; } = null;
            public string message { get; set; } = null;
            public DateTime createdAt { get; set; } = DateTime.UtcNow;
        }


        //SignUp Table
        [Table("userLog")]
        public class SignUp
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int userId { get; set; }
            public string fullName { get; set; } = null;
            public string emailId { get; set; } = null;
            public string password { get; set; } = null;
        }

        //Login DTO
        public class LoginDTO
        {
            public string emailId { get; set; } = null;
            public string password { get; set; } = null;
        }

        //Admin Table
        [Table("adminCredentials")]
        public class adminLogin
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int userId { get; set; }
            public string emailId { get; set; } = null;
            public string password { get; set; } = null;
        }

    }
}
