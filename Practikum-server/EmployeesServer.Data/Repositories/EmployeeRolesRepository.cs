using EmployeesServer.Core.Entities;
using EmployeesServer.Core.Repositories;
using EmployeesServer.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeRoles = EmployeesServer.Core.Entities.EmployeeRoles;

namespace EmployeesServer.Data.Repositories
{
    public class EmployeeRolesRepository : IEmployeeRolesRepository
    {
        private readonly DataContext _context;
        public EmployeeRolesRepository(DataContext context)
        {
                _context = context;
        }
        public async Task<IEnumerable<EmployeeRoles>> GetEmployeeRolesAsync()
        {
            return await _context.EmployeeRoles.ToListAsync();
        }
        public async Task<EmployeeRoles> GetByIdAsync(int Eid, int Rid)
        {
            return await _context.EmployeeRoles.FirstAsync(e => e.EmployeeId == Eid&&e.RoleId==Rid);
        }
        public async Task<EmployeeRoles> AddEmployeeRolesAsync(EmployeeRoles employeeRole)
        {
            _context.EmployeeRoles.Add(employeeRole);
            await _context.SaveChangesAsync();
            return employeeRole;
        }
        public async Task<EmployeeRoles> UpdateEmployeeRolesAsync(int Eid, int Rid, EmployeeRoles employeeRole)
        {
            var employeeR = _context.EmployeeRoles.ToList().Find(e => e.EmployeeId == Eid && e.RoleId == Rid);
            if (employeeR != null)
            {
                employeeR.isDirector=employeeRole.isDirector;
                employeeR.StartRole = employeeRole.StartRole;
                await _context.SaveChangesAsync();
                return employeeR;
            }
          ;
            return null;
        }
        public async Task DeleteEmployeeRolesAsync(int Eid, int Rid)
        {
            var employeeR = _context.EmployeeRoles.ToList().Find(e => e.EmployeeId == Eid && e.RoleId == Rid);
            if (employeeR != null)
                _context.EmployeeRoles.Remove(employeeR);
            await _context.SaveChangesAsync();
        }
    }
}
