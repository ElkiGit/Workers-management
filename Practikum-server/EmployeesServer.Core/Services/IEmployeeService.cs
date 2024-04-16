using EmployeesServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesServer.Core.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetByIdAsync(int id);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(int id, Employee employee);
        Task<Employee> UpdateEmployeeAsync(int id, EmployeeRoles value);
        Task DeleteEmployeeAsync(int id);
    }
}
