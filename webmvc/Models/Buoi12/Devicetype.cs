using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace webmvc.Models.Buoi12
{
    public class Devicetype
    {
        [Key]
        public int DevicetypeId { get; set; }
        [Required(ErrorMessage = "Tên loại thiết bị không được để trống")]
        public string DevicetypeName { get; set; }
        
        // 1 - equipments
        public virtual ICollection<Equipment>? Equipments { get; set; }



    }
}