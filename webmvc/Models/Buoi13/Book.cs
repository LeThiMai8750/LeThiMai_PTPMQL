using System.ComponentModel.DataAnnotations;
namespace  webmvc.Models.Buoi13
{
    public class Book
    {
        [Key]
        public int Id { get; set;}
        public string Title { get; set;} = string.Empty;
        public string Author { get; set;} = string.Empty;
        public string Categories { get; set;} = string.Empty;
        public int PublishYear { get; set;}
        public decimal Price { get; set;}
        public int Quantity { get; set;}

        public string Description { get; set;}
        public DateTime Time { get; set;} = DateTime.Now;
        public bool IsAvailable {get;set;} = true;
    }
}