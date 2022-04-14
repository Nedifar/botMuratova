using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleBotBack.Models
{
    public class Technician : User
    {
        [Key]
        public int idTechnician { get; set; }
        public string telegramId { get; set; }
        public bool isTelegramActivated { get; set; }
        public double avgPoint { get; set; }
        public virtual List<Request> Requests { get; set; } = new List<Request>();
        public virtual List<HistoryService> HistoryServices { get; set; } = new List<HistoryService>();
        public virtual List<Vacation> Vacations { get; set; } = new List<Vacation>();
        public string fullName
        {
            get
            {
                return lastName + " " + firstName + " " + middleName;
            }
        }
    }
}
