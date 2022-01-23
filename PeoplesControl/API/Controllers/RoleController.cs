using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.ReadServices;
using Logic.WriteServices;
using Logic.WebEntities;
using Logic.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRoleReadService _readService;
        IRoleWriteService _writeService;
        IAuthenticationService _authentication;

        public RoleController(IRoleReadService readService, IRoleWriteService writeService, IAuthenticationService authentication)        
        {
            _readService = readService;
            _writeService = writeService;
            _authentication = authentication;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RoleController>
        [HttpPost]
        public ActionStatus<GetRoleDTO> Post([FromHeader] string Authorization, [FromBody] CreateRoleDTO entity)
        {
            _authentication.Authentication(Authorization);
            return _writeService.Add(entity);
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
