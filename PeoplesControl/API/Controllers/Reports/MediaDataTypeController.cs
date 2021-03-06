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
    public class MediaDataTypeController : ControllerBase
    {
        IMediaDataTypeWriteService _mediaDataTypeWriteService;
        IMediaDataTypeReadService _mediaDataTypeReadService;
        IAuthorizationService _authorizationService;
        IConfiguration _configuration;

        public MediaDataTypeController(IMediaDataTypeReadService mediaDataTypeReadService, IMediaDataTypeWriteService mediaDataTypeWriteService, IAuthorizationService authorizationService, IConfiguration configuration)
        {
            _mediaDataTypeReadService = mediaDataTypeReadService;
            _mediaDataTypeWriteService = mediaDataTypeWriteService;
            _authorizationService = authorizationService;
            _configuration = configuration;
        }

        // GET: api/<MediaDataTypeController>
        [HttpGet]
        public RequestStatus<List<GetMediaDataTypeDTO>> Get([FromHeader] string Authorization)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:MediaDataType:Get"]);
            if (isAuthenticated){
                return _mediaDataTypeReadService.GetAll();
            }
            else
            {
                return null;
            }
        }

        // GET api/<MediaDataTypeController>/5
        [HttpGet("{id}")]
        public RequestStatus<GetMediaDataTypeDTO> Get([FromHeader] string Authorization, long id)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:MediaDataType:Get"]);
            if (isAuthenticated){
                return _mediaDataTypeReadService.Get(id);
            }
            else
            {
                return null;
            }
        }

        // POST api/<MediaDataTypeController>
        [HttpPost]
        public RequestStatus<GetMediaDataTypeDTO> Post([FromHeader] string Authorization, [FromBody] CreateMediaDataTypeDTO createEntity)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:MediaDataType:Add"]);
            if (isAuthenticated){
                return _mediaDataTypeWriteService.Add(createEntity);
            }
            else
            {
                return null;
            }
        }

        // PUT api/<MediaDataTypeController>
        [HttpPut("{id}")]
        public bool Put([FromHeader] string Authorization, [FromBody] UpdateMediaDataTypeDTO updateEntity)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:MediaDataType:Update"]);
            if (isAuthenticated){
                return _mediaDataTypeWriteService.Update(updateEntity);
            }
            else
            {
                return false;
            }
        }

        // DELETE api/<MediaDataTypeController>/5
        [HttpDelete("{id}")]
        public void Delete([FromHeader] string Authorization, long id)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:MediaDataType:Delete"]);
            if (isAuthenticated){
                _mediaDataTypeWriteService.Delete(id);
            }
        }
    }
}
