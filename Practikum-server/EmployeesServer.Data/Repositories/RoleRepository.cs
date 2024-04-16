using EmployeesServer.Core.Entities;
using EmployeesServer.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesServer.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _context;
        public RoleRepository(DataContext context)
        {
            _context = context; 
        }
        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _context.Role.ToListAsync();
        }
        public async Task<Role> GetByIdAsync(int id)
        {
            return await _context.Role.FirstAsync(r => r.Id == id);
        }
        public async Task<Role> AddRoleAsync(Role role)
        {
            _context.Role.Add(role);
            await _context.SaveChangesAsync();
            var roleC=_context.Role.ToList().Find(r => r.Name == role.Name);
            return roleC;
        }
        public async Task<Role> UpdateRoleAsync(int id, Role role)
        {
            var r = _context.Role.ToList().Find(e => e.Id == id);
            if (r != null)
            {
                r.Name = role.Name; 
                await _context.SaveChangesAsync();
                return r;
            }                       
            return null;
        }
        public async Task DeleteRoleAsync(int id)
        {
            var r = _context.Role.ToList().Find(e => e.Id == id);
            if (r != null)
                _context.Role.Remove(r);
            await _context.SaveChangesAsync();
        }

        

        

        
    }
}
