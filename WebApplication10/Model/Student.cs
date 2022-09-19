using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication10.Model
{
    public class StudentLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class StudentRegister
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImagePath { get; set; }

    }
    public class Student 
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string ImagePath { get; set; }

        public int? RegFormId { get; set; }
        [ForeignKey("RegFormId")]
        public RegForm? RegForm { get; set; }

    }
}
