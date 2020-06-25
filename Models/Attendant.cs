using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApp.Models
{
    public class Attendant
    {
        [Key]
        public int AttendantId { get; set; }
        public User User { get; set; }

        [ForeignKey("Class")]
        public int Class_Id { get; set; }
        public Class Class { get; set; }
    }
}