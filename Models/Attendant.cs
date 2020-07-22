using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApp.Models
{
    public class Attendant
    {
        [Key]
        public virtual int AttendantId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Class")]
        public virtual int Class_Id { get; set; }
        public virtual Class Class { get; set; }
    }
}