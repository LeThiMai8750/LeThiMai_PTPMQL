using System.ComponentModel.DataAnnotations;

namespace webmvc.Models.Buoi12
{
    public class Stockout
    {
        [Key]
        public int StockoutId { get; set;}
        public DateTime OrderTime { get; set;} = DateTime.Now;

        public virtual ICollection<Stockoutdt>? Stockoutdts{ get; set;}  

    }
}