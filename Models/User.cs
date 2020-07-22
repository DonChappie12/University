using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace UniversityApp.Models
{
    public class User : IdentityUser
    {
        // *** Since using Proxies or lazy loading make sure that they're virtual ***
        public virtual List<Attendant> Attendant { get; set; }
        public virtual List<Class> Class { get; set; }
        public virtual List<Grades> Grade { get; set; }
        public virtual List<Message> Message { get; set; }
        public virtual List<Post> Post { get; set; }

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