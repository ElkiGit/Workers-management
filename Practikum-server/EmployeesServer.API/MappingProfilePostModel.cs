using AutoMapper;
using EmployeesServer.API.Models;
using EmployeesServer.Core.Entities;

namespace EmployeesServer.API
{
    public class MappingProfilePostModel:Profile
    {
        
        public MappingProfilePostModel()
        {

            CreateMap<RolePostModel, Role>().ReverseMap();
            

            CreateMap<EmployeeRolesPostModel, EmployeeRoles>().ReverseMap();
              

            CreateMap<EmployeePostModel, Employee>().ReverseMap();
               
        }

    }
    
}
