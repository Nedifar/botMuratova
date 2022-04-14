using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleBotBack.Models
{
    public class TypeProblem
    {
        [Key]
        public int idTypeProblem { get; set; }
        public string Name { get; set; }
        public virtual List<Request> Requests { get; set; } = new List<Request>();
    }
}
