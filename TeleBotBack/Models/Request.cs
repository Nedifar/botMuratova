using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleBotBack.Models
{
    public class Request
    {
        [Key]
        public int idRequest { get; set; }
        public DateTime dateCreated { get; set; }
        public string problem { get; set; }
        public string status { get; set; }
        public int idViewProblem { get; set; }
        public virtual ViewProblem ViewProblem { get; set; }
        public int idTypeProblem { get; set; }
        public virtual TypeProblem TypeProblem { get; set; }
        [ForeignKey("ItOtdelEmployee")]
        public int idItOtdelEmployee { get; set; }
        public virtual ItOtdelEmployee ItOtdelEmployee { get; set; }
        public int? idTechnician { get; set; }
        public Technician Technician { get; set; }
        public DateTime? dateClosed { get; set; }
        public virtual List<HistoryService> HistoryServices { get; set; } = new List<HistoryService>();
        public int idPlacement { get; set; }
        public virtual Placement Placement { get; set; }
    }
}
