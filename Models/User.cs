using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace UniversityApp.Models
{
    public class User : IdentityUser
    {
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