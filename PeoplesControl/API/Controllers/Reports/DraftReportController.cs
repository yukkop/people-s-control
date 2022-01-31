using DataBase.Models;
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
    public class DraftReportController : ControllerBase
    {
        IDraftReportWriteService _draftReportWriteService;
        IDraftReportReadService _draftReportReadService;
        IAuthorizationService _authorizationService;

        IConfiguration _configuration;

        public DraftReportController(IDraftReportReadService draftReportReadService, IDraftReportWriteService draftReportWriteService,
                                IAuthorizationService authorizationService, IConfiguration configuration)
        {
            _draftReportReadService = draftReportReadService;
            _draftReportWriteService = draftReportWriteService;

            _authorizationService = authorizationService;
            _configuration = configuration;
        }

        [HttpGet]
        public RequestStatus<List<GetDraftReportDTO>> Get([FromHeader] string Authorization)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:DraftReport:Get"]);
            if (isAuthenticated)
            {
                return _draftReportReadService.Get(userId);
            }
            else
            {
                return RequestStatus<List<GetDraftReportDTO>>.AuthFailed();
            }
        }

        [HttpGet("all")]
        public RequestStatus<List<GetDraftReportDTO>> GetAll([FromHeader] string Authorization)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:DraftReport:Get"]);
            if (isAuthenticated)
            {
                return _draftReportReadService.GetAll();
            }
            else
            {
                return RequestStatus<List<GetDraftReportDTO>>.AuthFailed();
            }
        }

        [HttpPost]
        public RequestStatus Post([FromHeader] string Authorization, [FromBody] CreateDraftReportDTO createEntity)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:DraftReport:Add"]);
            if (isAuthenticated)
            {
                return _draftReportWriteService.Create(createEntity, userId);
            }
            else
            {
                return RequestStatus.AuthFailed();
            }
        }

        [HttpPut("{id}")]
        public RequestStatus Update([FromHeader] string Authorization, [FromBody] UpdateDraftReportDTO updateEntity)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:DraftReport:Add"]);
            if (isAuthenticated)
            {
                _draftReportWriteService.Update(updateEntity);
                return RequestStatus.Ok();
            }
            else
            {
                return RequestStatus.AuthFailed();
            }
        }


        [HttpDelete("{id}")]
        public RequestStatus Delete([FromHeader] string Authorization, long id)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:DraftReport:Add"]);
            if (isAuthenticated)
            {
                _draftReportWriteService.Delete(id);
                return RequestStatus.Ok();
            }
            else
            {
                return RequestStatus.AuthFailed();
            }
        }

    }
}
