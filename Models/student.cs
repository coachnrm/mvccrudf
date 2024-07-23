using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvccrudf.Models
{
    [Table("student")]
    public class student
    {
        [Key]
        public int id {get; set;}
        public String studentname {get; set;}
        public String studentphone {get; set;}
        public int skillid {get; set;}
        [ForeignKey("skillid")]
        public virtual skill Skill {get; set;}
        public int statusid {get; set;}
        [ForeignKey("statusid")]
        public virtual status Status {get; set;}
    }
}