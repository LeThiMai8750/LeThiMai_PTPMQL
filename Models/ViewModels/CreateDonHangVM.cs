using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using webmvc.Models.Entities;

namespace webmvc.Models.ViewModels
{
    public class CreateDonHangVM
    {
        public string Id { get; set; }

         [Required]
         public string MaKhachHang { get; set; }
         public DateTime NgayDat { get; set; } = DateTime.Now;

        // dropdown 
        
        public List<Chitietdh> Chitietdhs { get; set; }

    }
}