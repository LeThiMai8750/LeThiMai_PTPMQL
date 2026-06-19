using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace webmvc.Models.Demo {
public class Author
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Name không được để trống")]
    [StringLength(50, ErrorMessage = "Tên tối đa 50 ký tự")]
    public string Name { get; set; }
    public string Annotation { get; set; }

    // List<KieuDuLieu> TenDanhSach = new List<KieuDuLieu>();
    public List<Picture>? Pictures { get; set; } = new List<Picture>();
}
}