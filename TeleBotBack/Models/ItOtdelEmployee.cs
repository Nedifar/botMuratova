using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleBotBack.Models
{
    public class ItOtdelEmployee : User
    {
        [Key]
        public int idItOtdelEmployee { get; set; }
        public virtual List<Request> Requests { get; set; } = new List<Request>();
    }
}
