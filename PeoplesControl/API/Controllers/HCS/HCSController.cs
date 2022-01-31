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
    public class HCSController : ControllerBase
    {
        IHCSWriteService _hCSWriteService;
        IHCSReadService _hCSReadService;
        IAuthorizationService _authorizationService;
        IConfiguration _configuration;

        public HCSController(IHCSReadService hCSReadService, IHCSWriteService hCSWriteService, IAuthorizationService authorizationService, IConfiguration configuration)
        {
            _hCSReadService = hCSReadService;
            _hCSWriteService = hCSWriteService;
            _authorizationService = authorizationService;
            _configuration = configuration;
        }

        [HttpGet]
        public RequestStatus<List<GetHCSDTO>> Get([FromHeader] string Authorization)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:HCS:Get"]);
            if (isAuthenticated)
            {
                return _hCSReadService.GetAll();
            }
            else
            {
                return RequestStatus<List<GetHCSDTO>>.AuthFailed();
            }
        }

        [HttpGet("{id}")]
        public RequestStatus<GetHCSDTO> Get([FromHeader] string Authorization, long id)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:HCS:Get"]);
            if (isAuthenticated)
            {
                return _hCSReadService.Get(id);
            }
            else
            {
                return RequestStatus<GetHCSDTO>.AuthFailed();
            }
        }

        [HttpPost]
        public RequestStatus Post([FromHeader] string Authorization, [FromBody] CreateHCSDTO createEntity)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:HCS:Add"]);
            if (isAuthenticated)
            {
                return _hCSWriteService.Create(createEntity, userId);
            }
            else
            {
                return RequestStatus.AuthFailed();
            }
        }

        [HttpPut("{id}")]
        public bool Put([FromHeader] string Authorization, [FromBody] UpdateHCSDTO updateEntity)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:HCS:Update"]);
            if (isAuthenticated)
            {
                return _hCSWriteService.Update(updateEntity, userId);
            }
            else
            {
                return false;
            }
        }

        [HttpPut("{hCSId}/resronsiblePersonId/{resronsiblePersonId}")]
        public bool UpdateResponsiblePerson([FromHeader] string Authorization, long hCSId, long resronsiblePersonId)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:HCS:Update"]);
            if (isAuthenticated)
            {
                return _hCSWriteService.UpdateResponsiblePerson(hCSId, userId, resronsiblePersonId);
            }
            else
            {
                return false;
            }
        }

        [HttpDelete("{id}")]
        public RequestStatus Delete([FromHeader] string Authorization, long id)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:HCS:Delete"]);
            if (isAuthenticated)
            {
                _hCSWriteService.Delete(id, userId);
                return RequestStatus.Ok();
            }
            else
            {
                return RequestStatus.AuthFailed();
            }
        }
    }
}
