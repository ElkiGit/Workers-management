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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employee.Where(e => e.isDelete == false).Include(e => e.EmployeeRoles).ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return  await _context.Employee.Include(e => e.EmployeeRoles).FirstAsync(e => e.Id == id && !e.isDelete);
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            var updateEmployee = _context.Employee.ToList().Find(e => e.Identity == employee.Identity);
           

            if (updateEmployee != null && updateEmployee.isDelete)
            {
                updateEmployee.FirstName = employee.FirstName;
                updateEmployee.LastName = employee.LastName;
                updateEmployee.Identity = employee.Identity;
                updateEmployee.StartWork = employee.StartWork;
                updateEmployee.BirthDate = employee.BirthDate;
                updateEmployee.Type = employee.Type;
                updateEmployee.isDelete = false;
                await _context.SaveChangesAsync();
                return updateEmployee;
            }
           
            employee.EmployeeRoles = employee.EmployeeRoles.ToList();
          
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();
           // _context.Entry(employee).State = EntityState.Detached; 
           // employee = await _context.Employee.Include(e => e.EmployeeRoles).FirstAsync(e => e.Id == employee.Id);

            return employee;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var e = _context.Employee.ToList().Find(e => e.Id == id);
            if (e != null)
                e.isDelete = true;
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            var e = _context.Employee.ToList().Find(e => e.Id == id && !e.isDelete);
            if (e != null )
            {
                e.FirstName=employee.FirstName;
                e.LastName=employee.LastName;
                e.Identity=employee.Identity;
                e.StartWork=employee.StartWork;
                e.BirthDate=employee.BirthDate;
                e.Type=employee.Type;
                e.isDelete = employee.isDelete;
                e.EmployeeRoles=employee.EmployeeRoles.ToList();
                await _context.SaveChangesAsync();
                return e;
            }
            return null;
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, EmployeeRoles value)
        {
            var employee = await _context.Employee.FirstOrDefaultAsync(e => e.Id == id && !e.isDelete);

            if (employee != null&&_context.Role.ToList().FirstOrDefault(r=>r.Id==value.RoleId)!=null)
            {
                value.EmployeeId = id;
                _context.EmployeeRoles.Add(value);
                await _context.SaveChangesAsync();
                employee = await _context.Employee.Include(e => e.EmployeeRoles).FirstOrDefaultAsync(e => e.Id == id);

                return employee;
            }

            return null;
        }
    }
}
