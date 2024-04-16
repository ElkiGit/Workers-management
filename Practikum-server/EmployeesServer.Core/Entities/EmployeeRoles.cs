using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesServer.Core.Entities
{
    public class EmployeeRoles
    {
       
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public bool isDirector { get; set; }
        public DateTime StartRole { get; set; }
    }
}
