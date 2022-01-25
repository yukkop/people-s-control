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
    public class ReportController : ControllerBase
    {
        IReportWriteService _reportWriteService;
        IReportReadService _reportReadService;
        IAuthorizationService _authorizationService;
        IReportViewWriteService _reportViewWriteService;
        IConfiguration _configuration;

        public ReportController(IReportReadService reportReadService, IReportWriteService reportWriteService, IReportViewWriteService reportViewWriteService, IAuthorizationService authorizationService, IConfiguration configuration)
        {
            _reportReadService = reportReadService;
            _reportWriteService = reportWriteService;
            _reportViewWriteService = reportViewWriteService;
            _authorizationService = authorizationService;
            _configuration = configuration;
        }

        // GET: api/<ReportController>
        [HttpGet]
        public ActionStatus<List<GetReportDTO>> Get([FromHeader] string Authorization, [FromBody] RequestReportsPageDTO pageSettings)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Report:Get"]))
            {
                return _reportReadService.GetPage(pageSettings);
            }
            else
            {
                return null;
            }
        }

        // GET api/<ReportController>/5
        [HttpGet("{id}")]
        public ActionStatus<GetReportDTO> Get([FromHeader] string Authorization, long id)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Report:Get"]))
            {
                return _reportReadService.Get(id);
            }
            else
            {
                return null;
            }
        }

        // POST api/<ReportController>
        [HttpPost]
        public ActionStatus<GetReportDTO> Post([FromHeader] string Authorization, [FromBody] CreateReportDTO createEntity)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Report:Add"]))
            {
                return _reportWriteService.Add(createEntity);
            }
            else
            {
                return null;
            }
        }

        // POST api/<ReportController>
        [HttpPost("view")]
        public ActionStatus<ReportView> PostReportView([FromHeader] string Authorization, [FromBody] ReportView reportView)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:ReportView:Add"]))
            {
                return _reportViewWriteService.Add(reportView);
            }
            else
            {
                return null;
            }
        }

        // PUT api/<ReportController>
        [HttpPut("{id}")]
        public bool Put([FromHeader] string Authorization, [FromBody] UpdateReportDTO updateEntity)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Report:Update"]))
            {
                return _reportWriteService.Update(updateEntity);
            }
            else
            {
                return false;
            }
        }

        // DELETE api/<ReportController>/5
        [HttpDelete("{id}")]
        public void Delete([FromHeader] string Authorization, long id)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Report:Delete"]))
            {
                _reportWriteService.Delete(id);
            }
        }
    }
}
