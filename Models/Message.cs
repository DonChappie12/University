using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApp.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public string MessageContent { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Post")]
        public int Post_Id { get; set; }
        public virtual Post Post { get; set; }
    }
}