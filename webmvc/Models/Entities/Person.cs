using System.ComponentModel.DataAnnotations;

namespace webmvc.Models.Entities
{
    public class Person
    {
        [Key]
        [Required(ErrorMessage = "Không được để trống")]
        [RegularExpression(@"^.{6,}$", ErrorMessage = "Phải có ít nhất 6 ký tự")]
        public string StudentCode { get; set;}
        
        [StringLength(50,ErrorMessage = "Tối đa 50 ký tự")]
        public string FullName { get; set;}
    }
}

