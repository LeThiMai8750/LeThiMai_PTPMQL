using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Humanizer;

namespace webmvc.Models.Buoi12
{
    public class Stockindt
    {
        [Key]
        public int StockindtId { get;set;}
        public int StockinId { get;set;}
        public int EquipmentId { get;set;}
        public int Quantity { get;set;}
        public decimal UnitPrice { get;set;}
        public decimal TotalPrice => Quantity * UnitPrice;

        [ForeignKey("StockinId")]
        public Stockin? Stockin{ get;set;}   
        [ForeignKey("EquipmentId")]
        public Equipment? Equipment{ get;set;}
    }
}