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
    public class AvatarController : ControllerBase
    {
        IAvatarWriteService _avatarWriteService;
        IAvatarReadService _avatarReadService;
        IAuthorizationService _authorizationService;

        public AvatarController(IAvatarReadService avatarReadService, IAvatarWriteService avatarWriteService, IAuthorizationService authorizationService)
        {
            _avatarReadService = avatarReadService;
            _avatarWriteService = avatarWriteService;
            _authorizationService = authorizationService;
        }

        // GET: api/<AvatarController>
        [HttpGet]
        public ActionStatus<List<GetAvatarDTO>> Get()
        {
            return _avatarReadService.GetAll();
        }

        // GET api/<AvatarController>/5
        [HttpGet("{id}")]
        public ActionStatus<GetAvatarDTO> Get(long id)
        {
            return _avatarReadService.Get(id);
        }

        // POST api/<AvatarController>
        [HttpPost]
        public ActionStatus<GetAvatarDTO> Post([FromBody] CreateAvatarDTO createEntity)
        {
            return _avatarWriteService.Add(createEntity);
        }

        // PUT api/<AvatarController>
        [HttpPut("{id}")]
        public bool Put([FromBody] UpdateAvatarDTO updateEntity)
        {
            return _avatarWriteService.Update(updateEntity);
        }

        // DELETE api/<AvatarController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _avatarWriteService.Delete(id);
        }
    }
}
