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
    public class ReportStatusController : ControllerBase
    {
        IReportStatusWriteService _reportStatusWriteService;
        IReportStatusReadService _reportStatusReadService;
        IAuthorizationService _authorizationService;
        IConfiguration _configuration;

        public ReportStatusController(IReportStatusReadService reportStatusReadService, IReportStatusWriteService reportStatusWriteService, IAuthorizationService authorizationService, IConfiguration configuration)
        {
            _reportStatusReadService = reportStatusReadService;
            _reportStatusWriteService = reportStatusWriteService;
            _authorizationService = authorizationService;
            _configuration = configuration;
        }

        // GET: api/<ReportStatusController>
        [HttpGet]
        public ActionStatus<List<GetReportStatusDTO>> Get([FromHeader] string Authorization)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:ReportStatus:Get"]))
            {
                return _reportStatusReadService.GetAll();
            }
            else
            {
                return null;
            }
        }

        // GET api/<ReportStatusController>/5
        [HttpGet("{id}")]
        public ActionStatus<GetReportStatusDTO> Get([FromHeader] string Authorization, long id)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:ReportStatus:Get"]))
            {
                return _reportStatusReadService.Get(id);
            }
            else
            {
                return null;
            }
        }

        // POST api/<ReportStatusController>
        [HttpPost]
        public ActionStatus<GetReportStatusDTO> Post([FromHeader] string Authorization, [FromBody] CreateReportStatusDTO createEntity)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:ReportStatus:Add"]))
            {
                return _reportStatusWriteService.Add(createEntity);
            }
            else
            {
                return null;
            }
        }

        // PUT api/<ReportStatusController>
        [HttpPut("{id}")]
        public bool Put([FromHeader] string Authorization, [FromBody] UpdateReportStatusDTO updateEntity)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:ReportStatus:Update"]))
            {
                return _reportStatusWriteService.Update(updateEntity);
            }
            else
            {
                return false;
            }
        }

        // DELETE api/<ReportStatusController>/5
        [HttpDelete("{id}")]
        public void Delete([FromHeader] string Authorization, long id)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:ReportStatus:Delete"]))
            {
                _reportStatusWriteService.Delete(id);
            }
        }
    }
}
