using System.ComponentModel.DataAnnotations;

namespace webmvc.Models.Entities
{
    public class Chitietdh
    {
        public int Id { get; set; }

        public string Madonhang { get; set; } = default!;
        public string Masanpham { get; set; } = default!;

        public int Soluong { get; set; }
        public decimal DonGia {get; set; }

        public virtual Donhang Donhang { get; set; } = default!;
        public virtual Sanpham Sanpham{ get; set; } = default!;
    }
}