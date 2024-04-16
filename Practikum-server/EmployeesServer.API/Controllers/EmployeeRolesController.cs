using AutoMapper;
using EmployeesServer.API.Models;
using EmployeesServer.Core.DTOs;
using EmployeesServer.Core.Entities;
using EmployeesServer.Core.Services;
using EmployeesServer.Data.Migrations;
using EmployeesServer.Service;
using Microsoft.AspNetCore.Mvc;
using EmployeeRoles = EmployeesServer.Core.Entities.EmployeeRoles;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeesServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRolesController : ControllerBase
    {
        private readonly IEmployeeRolesService _employeeRolesService;
        private readonly IMapper _mapper;
        public EmployeeRolesController(IEmployeeRolesService employeeRolesService,IMapper mapper)
        {
            _employeeRolesService = employeeRolesService;
            _mapper = mapper;
        }
        // GET: api/<EmployeeRolesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var listDTO = await _employeeRolesService.GetEmployeeRolesAsync();
            return Ok(_mapper.Map<IEnumerable<EmployeeRolesDTO>>(listDTO));
        }

        // GET api/<EmployeeRolesController>/5
        [HttpGet("{id}/{Rid}")]
        public async Task<IActionResult> Get(int id,int Rid)
        {
            var employeeR = await _employeeRolesService.GetByIdAsync(id,Rid);
            if (employeeR is null)
                return NotFound();
            return Ok(_mapper.Map<EmployeeRolesDTO>(employeeR));
        }

        // POST api/<EmployeeRolesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeRolesPostModel employeeRoles)
        {
            var employeeRPost=_mapper.Map<EmployeeRoles>(employeeRoles);
            var employeeRolesDTO = await _employeeRolesService.AddEmployeeRolesAsync(employeeRPost);
            return Ok(_mapper.Map<EmployeeRolesDTO>(employeeRolesDTO));
        }

        // PUT api/<EmployeeRolesController>/5
        [HttpPut("{id}/{Rid}")]
        public async Task<IActionResult> Put(int id,int Rid, [FromBody] EmployeeRoles employeeRoles)
        {
            var employeeR = await _employeeRolesService.GetByIdAsync(id,Rid);
            if (employeeR is null)
                return NotFound();
            var employeeRolesDTO = await _employeeRolesService.UpdateEmployeeRolesAsync(id, Rid, employeeRoles);
            return Ok(_mapper.Map<EmployeeRolesDTO>(employeeRolesDTO));
        }

        // DELETE api/<EmployeeRolesController>/5
        [HttpDelete("{id}/{Rid}")]
        public async Task Delete(int id,int Rid)
        {
            await _employeeRolesService.DeleteEmployeeRolesAsync(id,Rid);
        }
    }
}
