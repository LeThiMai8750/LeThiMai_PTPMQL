using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webmvc.Models.Demo;

namespace webmvc.Models.ViewModels
{
    public class ArtVM
    {
    public int Id { get; set; }
    [Required(ErrorMessage = "Name không được để trống")]
    [StringLength(50, ErrorMessage = "Tên tối đa 50 ký tự")]
    public string Name { get; set; }
    
    public string ImagePath { get; set;}
     public int AuthorId { get; set; }

    public List<Picture>? Pictures { get; set; } = new List<Picture>();
    }
}