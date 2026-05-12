
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace webmvc.Models.Buoi12
{
    public class Suplier
    {
        [Key]
        public int SuplierId { get; set; }
                [Required(ErrorMessage = "Tên nhà cung cấp không được để trống")]
        public string SuplierName { get; set; }

        
        
    }
}