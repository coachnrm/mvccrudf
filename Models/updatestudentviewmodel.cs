namespace mvccrudf.Models
{
    public class updatestudentviewmodel
    {
        public int id {get; set;}
        public String studentname {get; set;}
        public String studentphone {get; set;}
        public int skillid {get; set;}
        public virtual skill Skill {get; set;}
        public int statusid {get; set;}
        public virtual status Status {get; set;}
    }
}