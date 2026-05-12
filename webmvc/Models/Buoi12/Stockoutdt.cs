using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webmvc.Models.Buoi12
{
    public class Stockoutdt
    {
        [Key]
        public int Id { get; set; }
        public int StockoutId { get; set; }
        public int EquipmentId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;

        [ForeignKey("StockoutId")]
        public Stockout? Stockout{ get; set; }
        [ForeignKey("EquipmentId")]
        public Equipment? Equipment{ get; set; }
    }
}