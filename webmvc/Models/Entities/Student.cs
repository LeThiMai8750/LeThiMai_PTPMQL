using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace webmvc.Models.Entities
{
    public class Student
    {
        [Key]
        [MinLength(6, ErrorMessage = "Ma sinh vien phai co it nhat 6 ky tu")]
        public string StudentCode { get; set; } = default!;
        [Required(ErrorMessage = "Ho va ten khong duoc de trong")]
        public string FullName { get; set; } = default!;
        public string? FacultyId { get; set; } 
        [ForeignKey("FacultyId")]
        public virtual Faculty? Faculty { get; set; } = default!;
    }
}