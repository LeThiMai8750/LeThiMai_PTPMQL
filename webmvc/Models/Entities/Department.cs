using System.ComponentModel.DataAnnotations;

namespace webmvc.Models.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string? TenPhong { get; set; }
        public virtual ICollection<Person>? Persons { get; set; }
    }
}
