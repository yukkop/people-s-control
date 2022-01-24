using Logic.Helpers;
using Logic.ReadServices;
using Logic.WebEntities;
using Logic.WriteServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvatarController : ControllerBase
    {
        IAvatarWriteService _avatarWriteService;
        IAvatarReadService _avatarReadService;
        IAuthorizationService _authorizationService;
        IConfiguration _configuration;

        public AvatarController(IAvatarReadService avatarReadService, IAvatarWriteService avatarWriteService, IAuthorizationService authorizationService, IConfiguration configuration)
        {
            _avatarReadService = avatarReadService;
            _avatarWriteService = avatarWriteService;
            _authorizationService = authorizationService;
            _configuration = configuration;
        }

        // GET: api/<AvatarController>
        [HttpGet]
        public ActionStatus<List<GetAvatarDTO>> Get([FromHeader] string Authorization)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Avatar:Get"]))
            {
                return _avatarReadService.GetAll();
            }
            else
            {
                return null;
            }
        }

        // GET api/<AvatarController>/5
        [HttpGet("{id}")]
        public ActionStatus<GetAvatarDTO> Get([FromHeader] string Authorization, long id)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Avatar:Get"]))
            {
                return _avatarReadService.Get(id);
            }
            else
            {
                return null;
            }
        }

        // POST api/<AvatarController>
        [HttpPost]
        public ActionStatus<GetAvatarDTO> Post([FromHeader] string Authorization, [FromBody] CreateAvatarDTO createEntity)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Avatar:Add"]))
            {
                return _avatarWriteService.Add(createEntity);
            }
            else
            {
                return null;
            }
        }

        // PUT api/<AvatarController>
        [HttpPut("{id}")]
        public bool Put([FromHeader] string Authorization, [FromBody] UpdateAvatarDTO updateEntity)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Avatar:Update"]))
            {
                return _avatarWriteService.Update(updateEntity);
            }
            else
            {
                return false;
            }
        }

        // DELETE api/<AvatarController>/5
        [HttpDelete("{id}")]
        public void Delete([FromHeader] string Authorization, long id)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Avatar:Delete"]))
            {
                _avatarWriteService.Delete(id);
            }
        }
    }
}
