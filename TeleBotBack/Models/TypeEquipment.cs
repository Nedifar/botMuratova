using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleBotBack.Models
{
    public class TypeEquipment
    {
        [Key]
        public int idTypeEquipment { get; set; }
        public string Name { get; set; }
        public virtual List<Equipment> Equipments { get; set; } = new List<Equipment>();
    }
}
