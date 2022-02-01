using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.ReadServices;
using Logic.WriteServices;
using Logic.WebEntities;
using Logic.Helpers;
using Microsoft.Extensions.Configuration;
using DataBase.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HCSTypeController : ControllerBase
    {
        IHCSTypeWriteService _hCSTypeWriteService;
        IHCSTypeReadService _hCSTypeReadService;
        IAuthorizationService _authorizationService;
        IConfiguration _configuration;

        public HCSTypeController(IHCSTypeReadService hCSTypeReadService, IHCSTypeWriteService hCSTypeWriteService, IAuthorizationService authorizationService, IConfiguration configuration)
        {
            _hCSTypeReadService = hCSTypeReadService;
            _hCSTypeWriteService = hCSTypeWriteService;
            _authorizationService = authorizationService;
            _configuration = configuration;
        }

        [HttpGet]
        public RequestStatus<List<GetHCSTypeDTO>> Get([FromHeader] string Authorization)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:HCSType:Get"]);
            if (isAuthenticated)
            {
                return _hCSTypeReadService.GetAll();
            }
            else
            {
                return RequestStatus<List<GetHCSTypeDTO>>.AuthFailed();
            }
        }

        [HttpGet("{id}")]
        public RequestStatus<GetHCSTypeDTO> Get([FromHeader] string Authorization, long id)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:HCSType:Get"]);
            if (isAuthenticated)
            {
                return _hCSTypeReadService.Get(id);
            }
            else
            {
                return RequestStatus<GetHCSTypeDTO>.AuthFailed();
            }
        }

        [HttpPost]
        public RequestStatus Post([FromHeader] string Authorization, [FromBody] CreateHCSTypeDTO createEntity)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:HCSType:Add"]);
            if (isAuthenticated)
            {
                return _hCSTypeWriteService.Create(createEntity);
            }
            else
            {
                return RequestStatus.AuthFailed();
            }
        }

        [HttpPut("{id}")]
        public bool Put([FromHeader] string Authorization, [FromBody] UpdateHCSTypeDTO updateEntity)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:HCSType:Update"]);
            if (isAuthenticated)
            {
                return _hCSTypeWriteService.Update(updateEntity);
            }
            else
            {
                return false;
            }
        }

        [HttpDelete("{id}")]
        public RequestStatus Delete([FromHeader] string Authorization, long id)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:HCSType:Delete"]);
            if (isAuthenticated)
            {
                _hCSTypeWriteService.Delete(id);
                return RequestStatus.Ok();
            }
            else
            {
                return RequestStatus.AuthFailed();
            }
        }
    }
}
