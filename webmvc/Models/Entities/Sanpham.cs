using System.ComponentModel.DataAnnotations;

namespace webmvc.Models.Entities
{
    public class Sanpham
    {
        [Key]
        public string Masanpham { get; set; } = default!;
        public string TenSanPham { get; set; } = default!;
        public int Soluongton { get; set; }
        public decimal Gia{get; set; }
        public virtual ICollection<Chitietdh>? ChiTietdhs { get; set; }

    }
}