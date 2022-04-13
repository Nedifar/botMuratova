using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationManagmentSystem.Models
{
    class context : DbContext
    {
        public context() : base("sql") { }
        private static context _context;
        public static context aGetContext()
        {
            if(_context==null)
            {
                _context = new context();
            }
            return _context;
        }
        public DbSet<Technician> Technicians { get; set; }
    }
}
