using AutoMapper;
using EmployeesServer.API.Models;
using EmployeesServer.Core.DTOs;
using EmployeesServer.Core.Entities;
using EmployeesServer.Core.Services;
using EmployeesServer.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeesServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public RoleController(IRoleService roleService,IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var listE = await _roleService.GetRolesAsync();
            return Ok(_mapper.Map<IEnumerable<RoleDTO>>(listE));
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var r =await _roleService.GetByIdAsync(id);
            if (r is null)
                return NotFound();
            return Ok(_mapper.Map<RoleDTO>(r));
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RolePostModel role)
        {
            var rolePost=_mapper.Map<Role>(role);
            var r = await _roleService.AddRoleAsync(rolePost);
            
            return Ok(_mapper.Map<RoleDTO>(r));
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RolePostModel role)
        {
            var r = await _roleService.GetByIdAsync(id);
            if (r is null)
                return NotFound();
            var roleDTO = await _roleService.UpdateRoleAsync(id, _mapper.Map<Role>(role));
            return Ok(_mapper.Map<RoleDTO>(roleDTO));
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _roleService.DeleteRoleAsync(id);
        }
    }
}
