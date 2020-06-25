using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApp.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string PostContent { get; set; }
        public User User { get; set; }
        public List<Message> Message { get; set; }

        public Post()
        {
            Message = new List<Message>();
        }
    }
}