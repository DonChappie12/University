using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApp.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        
        [ForeignKey("User")]
        public int User_Id { get; set; }
        public User User { get; set; }
        public List<Attendant> Attendant { get; set; }
        public Class()
        {
            Attendant = new List<Attendant>();
        }
    }
}