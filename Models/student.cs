using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvccrudf.Models
{
    public class student
    {
        [Key]
        public int id {get; set;}
        public String studentname {get; set;}
        public String studentphone {get; set;}
        public int skillid {get; set;}
        [ForeignKey("skillid")]
        public virtual skill Skill {get; set;}
    }
}