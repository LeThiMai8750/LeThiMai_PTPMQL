using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace webmvc.Models.Demo
{
    public class Picture
    {
        [Key]
        public int Id { get; set;}
        [Required(ErrorMessage = "Name không được để trống")]
        [StringLength(50, ErrorMessage = "Tên tối đa 50 ký tự")]
        public string Name { get; set;}
        public string ImagePath { get; set;}

        public int AuthorId { get; set;}
        [ForeignKey("AuthorId")]
        public Author? Author {get; set;} 

    }
}