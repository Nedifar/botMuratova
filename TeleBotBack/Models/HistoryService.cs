using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleBotBack.Models
{
    public class HistoryService
    {
        [Key]
        public int idHistoryService { get; set; }
        public int idTechnician { get; set; }
        public virtual Technician Technician { get; set; }
        public int idRequest { get; set; }
        public virtual Request Request { get; set; }
        public int Point { get; set; }
        public int idItOtdelEmployee { get; set; }
        public ItOtdelEmployee ItOtdelEmployee { get; set; }
        public int runTime { get; set; }
    }
}
