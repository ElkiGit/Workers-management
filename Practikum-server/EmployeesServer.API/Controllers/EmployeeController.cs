using AutoMapper;
using EmployeesServer.API.Models;
using EmployeesServer.Core.DTOs;
using EmployeesServer.Core.Entities;
using EmployeesServer.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeesServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService,IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employeeList =await _employeeService.GetEmployeesAsync();
            return Ok(_mapper.Map<IEnumerable<EmployeeDTO>>(employeeList));
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var e=await _employeeService.GetByIdAsync(id);
            if(e is null&&e.isDelete==true)
                return NotFound();
            var employeeDto=_mapper.Map<EmployeeDTO>(e);
            return Ok(employeeDto);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeePostModel value)
        {
            
            Employee e = _mapper.Map<Employee>(value);
            var employee = await _employeeService.AddEmployeeAsync(e);
            return Ok(_mapper.Map<EmployeeDTO>(employee));
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeePostModel value)
        {
            var e = await _employeeService.GetByIdAsync(id);
            if (e is null)
                return NotFound();
            var emp = _mapper.Map<Employee>(value);
            var employee = await _employeeService.UpdateEmployeeAsync(id, emp);
            return Ok(_mapper.Map<EmployeeDTO>(employee));
        }

        [HttpPut("EmployeeRole/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeRolesPostModel value)
        {
            var employeeR = _mapper.Map<EmployeeRoles>(value);
            var e = await _employeeService.UpdateEmployeeAsync(id, employeeR);
            if (e is null)
                return NotFound();
            return Ok(_mapper.Map<EmployeeDTO>(e));
        }
        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
        }
    }
}
