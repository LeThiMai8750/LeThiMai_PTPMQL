using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webmvc.Models.Buoi12
{
    public class Equipment
    {
        [Key]
        public int EquipmentId { get; set;}
        [Required(ErrorMessage = "Tên  thiết bị không được để trống")]
        public string EquipmentName { get; set;}
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Giá phải >= 0")]
        public decimal Price { get; set;}
        [Range(0, double.MaxValue, ErrorMessage = "Tồn kho >= 0")]
        public int Stock { get; set;}

        public int DevicetypeId { get; set;}
        [ForeignKey("DevicetypeId")]
        public Devicetype? Devicetype { get; set;}
    }
}