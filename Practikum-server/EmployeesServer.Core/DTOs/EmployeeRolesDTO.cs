using EmployeesServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesServer.Core.DTOs
{
    public class EmployeeRolesDTO
    {   
        public int RoleId { get; set; }
        public bool isDirector { get; set; }
        public DateTime StartRole { get; set; }
    }
}
