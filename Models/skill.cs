using System.ComponentModel.DataAnnotations;

namespace mvccrudf.Models
{
    public class skill
    {
        [Key]
        public int id {get; set;}
        public string skillname {get; set;}
    }
}