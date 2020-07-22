using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApp.Models
{
    public class Grades
    {
        [Key]
        public int GradeId { get; set; }
        public double Grade { get; set; }
        public virtual User User { get; set; }
    }
}