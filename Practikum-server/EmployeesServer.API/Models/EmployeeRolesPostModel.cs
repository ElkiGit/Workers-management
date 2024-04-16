using EmployeesServer.Core.Entities;

namespace EmployeesServer.API.Models
{
    public class EmployeeRolesPostModel
    {
        public int RoleId { get; set; }
        public bool isDirector { get; set; }
        public DateTime StartRole { get; set; }
    }
}
