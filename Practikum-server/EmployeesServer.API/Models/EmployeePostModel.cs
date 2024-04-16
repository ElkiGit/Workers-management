using System.Runtime.Serialization;
using System.Xml.Linq;
using Type = EmployeesServer.Core.Entities.Type;

namespace EmployeesServer.API.Models
{

    public class EmployeePostModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identity { get; set; }
        public DateTime StartWork { get; set; }
        public DateTime BirthDate { get; set; }
        public Type Type { get; set; }
        public List<EmployeeRolesPostModel> EmployeeRoles { get; set; }
    }
}
