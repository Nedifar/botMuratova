using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleBotBack.Models
{
    public class Vacation
    {
        [Key]
        public int idVacation { get; set; }
        public int idTechnician { get; set; }
        public virtual Technician Technician { get; set; }
        public DateTime dateBegin { get; set; }
        public DateTime dateEnd { get; set; }
        public string Comment { get; set; }
        public bool isVacationNow
        {
            get
            {
                if (DateTime.Now >= dateBegin && DateTime.Now <= dateEnd)
                {
                    return true;
                }
                else
                    return false;
            }
        }
    }
}
