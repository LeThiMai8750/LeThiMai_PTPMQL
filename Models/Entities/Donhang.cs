using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webmvc.Models.Entities
{
    public class Donhang
{

        [Key]
        public string Madonhang { get; set; } = default!;

        public DateTime NgayDat { get; set; } = DateTime.Now;

        // 🔥 Khóa ngoại
        public string MaKhachHang { get; set; } = default!;

        // 🔥 Navigation
        [ForeignKey("MaKhachHang")]
        // tên class - tên biến
        public virtual Khachhang? Khachhang { get; set; }

        // 🔥 1-n
        public virtual ICollection<Chitietdh>? Chitietdhs { get; set; }

    }
}