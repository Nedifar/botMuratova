using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationManagmentSystem.Models
{
    public class Technician
    {
        [Key]
        public int idTechnician { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string telegramId { get; set; }
        public bool telegramProtected { get; set; }
    }
}
