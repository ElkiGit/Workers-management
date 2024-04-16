using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesServer.Core.Entities
{
    public enum Type { Male,Female } ;
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identity { get; set; }
        public DateTime StartWork { get; set; }
        public DateTime BirthDate { get; set; }
        public Type Type { get; set; }
        public bool isDelete { get; set; }=false;
        public List<EmployeeRoles> EmployeeRoles { get; set; }
    }
}
