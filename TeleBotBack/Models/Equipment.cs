using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleBotBack.Models
{
    public class Equipment
    {
        [Key]
        public int idEquipment { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public bool isWork { get; set; } = true;
        public int idTypeEquipment { get; set; }
        public virtual TypeEquipment TypeEquipment { get; set; }
    }
}
