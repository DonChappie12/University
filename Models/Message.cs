using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApp.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public string MessageContent { get; set; }
        public User User { get; set; }

        [ForeignKey("Post")]
        public int Post_Id { get; set; }
        public Post Post { get; set; }
    }
}