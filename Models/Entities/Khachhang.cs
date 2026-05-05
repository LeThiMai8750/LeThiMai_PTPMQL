using System.ComponentModel.DataAnnotations;

namespace webmvc.Models.Entities
{
    public class Khachhang
    {
        [Key]
        [Required(ErrorMessage = "Mã khách hàng không được để trống")]
        [StringLength(10)]
        public string MaKhachHang { get; set; } = default!;

        [Required(ErrorMessage = "Tên khách hàng không được để trống")]
        [StringLength(100)]
        public string TenKhachHang { get; set; } = default!;

        [StringLength(15)]
        public string? SoDienThoai { get; set; }

        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string? Email { get; set; }


        // 1 khách hàng có list đơn hàng
         public virtual ICollection<Donhang>? Donhangs {get; set;} 
    }
}