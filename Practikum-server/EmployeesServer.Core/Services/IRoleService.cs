using EmployeesServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesServer.Core.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetRolesAsync();
        Task<Role> GetByIdAsync(int id);
        Task<Role> AddRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(int id, Role role);
        Task DeleteRoleAsync(int id);
    }
}
