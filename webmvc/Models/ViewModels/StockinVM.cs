using webmvc.Models.Buoi12;
namespace webmvc.Models.ViewModels
{
    public class StockinVM
    {
        public int OrderId { get; set; }
        public DateTime  OrderDate { get; set; }
        public int DevicetypeId { get; set; }
        public int EquipmentId { get; set; }
        public List<StockindtVM> StockindtVMs { get; set; }
        = new List<StockindtVM>();

}
}