using EmployeesServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = EmployeesServer.Core.Entities.Type;

namespace EmployeesServer.Core.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identity { get; set; }
        public DateTime StartWork { get; set; }
        public DateTime BirthDate { get; set; }
        public Type Type { get; set; }
        public List<EmployeeRolesDTO> EmployeeRoles { get; set; }
    }
}
