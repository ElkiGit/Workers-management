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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;    
        }
        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _roleRepository.GetRolesAsync();
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _roleRepository.GetByIdAsync(id);
        }
        public async Task<Role> AddRoleAsync(Role role)
        {
            return await _roleRepository.AddRoleAsync(role);
        } 

        public async Task<Role> UpdateRoleAsync(int id, Role role)
        {
            return await _roleRepository.UpdateRoleAsync(id, role);
        }
        public async Task DeleteRoleAsync(int id)
        {
            await _roleRepository.DeleteRoleAsync(id);
        }
    }
}
