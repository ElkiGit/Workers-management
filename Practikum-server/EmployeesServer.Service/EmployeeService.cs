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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _employeeRepository.GetEmployeesAsync();
        }
        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.AddEmployeeAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            return await _employeeRepository.UpdateEmployeeAsync(id, employee);
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, EmployeeRoles value)
        {
            return await _employeeRepository.UpdateEmployeeAsync(id, value);
        }
    }
}
