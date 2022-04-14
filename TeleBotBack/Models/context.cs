using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleBotBack.Models
{
    class context : DbContext
    {
        public context() : base("sql") { }
        private static context _context;
        public static context aGetContext()
        {
            if (_context == null)
            {
                _context = new context();
            }
            return _context;
        }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<HistoryService> HistoryServices { get; set; }
        public DbSet<ItOtdelEmployee> ItOtdelEmployees { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<TypeEquipment> TypeEquipments { get; set; }
        public DbSet<TypeProblem> TypeProblems { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<ViewProblem> ViewProblems { get; set; }
        public DbSet<RequestMessageId> RequestMessageIds { get; set; }
    }
}
