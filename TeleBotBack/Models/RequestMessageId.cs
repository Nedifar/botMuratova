using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleBotBack.Models
{
    public class RequestMessageId
    {
        [Key]
        public int idRequestMessageId { get; set; }
        public int idRequest { get; set; }
        public virtual Request Request { get; set; }
        public int chatId { get; set; }
        public int messageId { get; set; }
    }
}
