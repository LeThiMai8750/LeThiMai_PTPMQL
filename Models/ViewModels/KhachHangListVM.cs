using System.ComponentModel.DataAnnotations;

namespace webmvc.Models.ViewModels
{
    public class KhachHangList
    {
        [Required]
        public string MaKhachHang { get; set; } = default!;
        [Required]
        public string TenKhachHang { get; set; } = default!;
    }
}