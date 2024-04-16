using EmployeesServer.Core.Entities;
using EmployeesServer.Core.Repositories;
using EmployeesServer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesServer.Service
{
    public class EmployeeRolesService : IEmployeeRolesService
    {
        private readonly IEmployeeRolesRepository _employeeRolesRepository;
        public async Task<IEnumerable<EmployeeRoles>> GetEmployeeRolesAsync()
        {
            return await _employeeRolesRepository.GetEmployeeRolesAsync();
        }
        public async Task<EmployeeRoles> GetByIdAsync(int Eid, int Rid)
        {
            return await _employeeRolesRepository.GetByIdAsync(Eid, Rid);
        }
        public async Task<EmployeeRoles> AddEmployeeRolesAsync(EmployeeRoles employeeRole)
        {
            return await _employeeRolesRepository.AddEmployeeRolesAsync(employeeRole);
        }
        public async Task<EmployeeRoles> UpdateEmployeeRolesAsync(int Eid, int Rid, EmployeeRoles employeeRole)
        {
            return await _employeeRolesRepository.UpdateEmployeeRolesAsync(Eid,Rid,employeeRole);
        }
        public async Task DeleteEmployeeRolesAsync(int Eid, int Rid)
        {
            await _employeeRolesRepository.DeleteEmployeeRolesAsync(Eid, Rid);
        }
    }
}
