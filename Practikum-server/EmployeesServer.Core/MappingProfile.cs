using AutoMapper;
using EmployeesServer.Core.DTOs;
using EmployeesServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesServer.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee,EmployeeDTO>().ReverseMap();
            CreateMap<Role,RoleDTO>().ReverseMap();
            CreateMap<EmployeeRoles, EmployeeRolesDTO>();
        }
    }
}
