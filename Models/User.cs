using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Role { get; set; }
        public List<Attendant> Attendant { get; set; }
        public List<Class> Class { get; set; }
        public List<Grades> Grade { get; set; }
        public List<Message> Message { get; set; }
        public List<Post> Post { get; set; }

        public User()
        {
            Attendant = new List<Attendant>();
            Class = new List<Class>();
            Grade = new List<Grades>();
            Message = new List<Message>();
            Post = new List<Post>();
        }
    }
}