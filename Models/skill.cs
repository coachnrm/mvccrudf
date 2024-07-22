using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvccrudf.Models
{
    [Table("skill")]
    public class skill
    {
        [Key]
        public int id {get; set;}
        public string skillname {get; set;}
    }
}