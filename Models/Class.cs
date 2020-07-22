using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApp.Models
{
    public class Class
    {
        [Key]
        public virtual int ClassId { get; set; }
        public virtual string ClassName { get; set; }
        public virtual User User { get; set; }
        public virtual List<Attendant> Attendant { get; set; }
        public Class()
        {
            Attendant = new List<Attendant>();
        }
    }
}