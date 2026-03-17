using System.ComponentModel.DataAnnotations;

namespace webmvc.Models.Entities
{
    public class Student
    {
        [Key]
        public string StudentCode { get; set;}
        public string FullName { get; set;}
    }
}

