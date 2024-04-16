using EmployeesServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesServer.Core.Services
{
    public interface IEmployeeRolesService
    {
        Task<IEnumerable<EmployeeRoles>> GetEmployeeRolesAsync();
        Task<EmployeeRoles> GetByIdAsync(int Eid, int Rid);
        Task<EmployeeRoles> AddEmployeeRolesAsync(EmployeeRoles employeeRole);
        Task<EmployeeRoles> UpdateEmployeeRolesAsync(int Eid, int Rid, EmployeeRoles employeeRole);
        Task DeleteEmployeeRolesAsync(int Eid, int Rid);
    }
}
