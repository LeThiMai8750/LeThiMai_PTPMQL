using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webmvc.Models.Buoi12
{
    public class Stockin
    {
        [Key]
        public int StockinId { get; set;}
        public DateTime OrderTime {get; set;} = DateTime.Now;

        public virtual ICollection<Stockindt>? Stockindts{ get; set;}
    
    }
}