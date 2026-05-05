using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace webmvc.Models.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống trường name")]
        public string? Ten { get; set; }
        public int Number { get; set; }

        [ForeignKey("TenPhong")]
        public string? TenPhong { get; set; }
        public Department? Department { get; set; }
    }
}

