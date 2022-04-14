using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleBotBack.Models
{
    public class User
    {
        public string login { get; set; }
        [Required]
        public string password { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}
